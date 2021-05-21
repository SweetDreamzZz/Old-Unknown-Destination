using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using softnaosu.Enums;
using softnaosu.Objects;
using softnaosu.Utils;

namespace softnaosu.Memory.Signatures
{
    public class SignatureBase
    {
        protected static bool ScanSignature(byte?[] pattern, IntPtr offset, out IntPtr pointerAddress)
        {
            pointerAddress = IntPtr.Zero;
            
            var memoryRegions = EnumerateMemoryRegions();
            
            foreach (var memoryRegion in memoryRegions)
            {
                if (Extensions.BiggerThanIntPtr(MemoryManager.Process?.MainModule?.BaseAddress ?? IntPtr.Zero, memoryRegion.BaseAddress))
                    continue;
                
                var bytes = MemoryManager.ReadBytes(memoryRegion.BaseAddress, (int)memoryRegion.RegionSize);
                if (FindSignatureAddressOffset(pattern, bytes) is var signatureAddressOffset  && signatureAddressOffset != IntPtr.Zero)
                {
                    pointerAddress = Extensions.AddIntPtr(offset,
                        Extensions.AddIntPtr(memoryRegion.BaseAddress, signatureAddressOffset));

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
            while (MemoryManager.VirtualQueryEx(MemoryManager.Process.Handle,
                address, out var mbi,
                (uint) Marshal.SizeOf(typeof(MemoryBasicInformation))) != 0)
            {
                if (mbi.State != State.MemFree && !mbi.Protect.HasFlag(Protect.PageGuard))
                    regions.Add(new MemoryRegion(mbi));

                address = Extensions.AddIntPtr(mbi.BaseAddress, mbi.RegionSize);
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