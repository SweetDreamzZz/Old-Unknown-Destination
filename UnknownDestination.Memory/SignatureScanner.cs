using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnknownDestination.Shared;
using UnknownDestination.Memory.Enums.MemoryBasicInformation;
using UnknownDestination.Memory.Extensions;
using UnknownDestination.Memory.Objects;

namespace UnknownDestination.Memory
{
    public static class SignatureScanner
    {
        [DllImport("kernel32.dll", SetLastError = true)]
        private static extern int VirtualQueryEx(IntPtr hProcess,
            IntPtr lpAddress,
            out MemoryBasicInformation lpBuffer,
            uint dwLength);
        
        public static bool Scan(byte?[] pattern, int offset, out IntPtr pointerAddress)
        {
            pointerAddress = IntPtr.Zero;

            var memoryRegions = EnumerateMemoryRegions();
            
            foreach (var memoryRegion in memoryRegions)
            {
                if ((Global.Process?.MainModule?.BaseAddress ?? IntPtr.Zero).BiggerThan(memoryRegion.BaseAddress))
                    continue;
                
                var bytes = MemoryManager.ReadBytes(memoryRegion.BaseAddress, (uint)memoryRegion.RegionSize);
                if (FindSignatureAddressOffset(pattern, bytes) is var signatureAddressOffset  && signatureAddressOffset != IntPtr.Zero)
                {
                    pointerAddress = memoryRegion.BaseAddress.Add(signatureAddressOffset).Add((IntPtr)offset);
                    
                    return true;
                }
            }

            return false;
        }
        
        private static List<MemoryRegion> EnumerateMemoryRegions()
        {
            var regions = new List<MemoryRegion>();
            var address = IntPtr.Zero;

            // catch every accessible region in game memory
            while (VirtualQueryEx(Global.Process.Handle,
                address, out var mbi,
                (uint) Marshal.SizeOf(typeof(MemoryBasicInformation))) != 0)
            {
                if (mbi.State != State.MemFree && !mbi.Protect.HasFlag(Protect.PageGuard))
                    regions.Add(new MemoryRegion(mbi));

                address = mbi.BaseAddress.Add(mbi.RegionSize);
            }

            return regions;
        }
        
        private static IntPtr FindSignatureAddressOffset(byte?[] pattern, byte[] target)
        {
            for (var i = 0; i + pattern.Length < target.Length; i++)
            {
                for (var j = 0; j < pattern.Length; j++)
                {
                    if (pattern[j] != null && pattern[j] != target[i + j])
                        break;

                    if (j + 1 == pattern.Length)
                        return (IntPtr) i;
                }
            }
            
            return IntPtr.Zero;
        }
    }
}