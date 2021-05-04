using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using softnaosu.Game.Enums;
using softnaosu.Game.Utils;

namespace softnaosu.Game.Memory
{
    public class Memory
    { 
        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern uint VirtualQueryEx(IntPtr hProcess,
            IntPtr lpAddress,
            out MemoryBasicInformation lpBuffer,
            uint dwLength);
        
        public void FindAddressBySignaturePattern(string pattern, out IntPtr address)
        {
            var signatureBytes = convertSignaturePatternToBytes(pattern);
            var memoryRegions = EnumerateMemoryRegions();

            foreach (var region in memoryRegions)
            {
                if (Extensions.BiggerThan(Global.Process?.MainModule?.BaseAddress ?? IntPtr.Zero, region.BaseAddress))
                    continue;

                var regionBytes = MemoryManager.Read(region.BaseAddress, (uint)region.RegionSize);
                var offset = compareBytes(signatureBytes, regionBytes);

                if (offset != IntPtr.Zero) 
                    address = Extensions.Add(region.BaseAddress, offset);
            }
            
            address = IntPtr.Zero;
        }
        
        private List<MemoryRegion> EnumerateMemoryRegions()
        {
            var memoryRegions = new List<MemoryRegion>();
            var currentAddress = IntPtr.Zero;
            
            while (VirtualQueryEx(Global.Process.Handle,
                currentAddress,
                out var mbi,
                (uint) Marshal.SizeOf(typeof(MemoryBasicInformation))) != 0)
            {
                if (mbi.State != State.MemFree && !mbi.Protect.HasFlag(Protect.PageGuard))
                {
                    memoryRegions.Add(new MemoryRegion(mbi));
                }

                currentAddress = Extensions.Add(mbi.BaseAddress, mbi.RegionSize);
            }

            return memoryRegions;
        }

        private byte?[] convertSignaturePatternToBytes(string pattern)
        {
            var chunks = pattern.Split(' ');
            var bytes = new byte?[chunks.Length];

            for (var i = 0; i < bytes.Length; i++)
            {
                var chunk = chunks[i];

                if (chunk == "??")
                    bytes[i] = null;
                else
                    bytes[i] = Convert.ToByte(chunk);
            }

            return bytes;
        }

        private IntPtr compareBytes(byte?[] signatureBytes, byte[] regionBytes)
        {
            for (var i = 0; i + signatureBytes.Length < regionBytes.Length; i++)
            {
                for (var j = 0; j < signatureBytes.Length; j++)
                {
                    if (signatureBytes[j] != null && signatureBytes[j] != regionBytes[i + j])
                        break;

                    if (j + 1 == signatureBytes.Length)
                        return (IntPtr) i;
                }
            }
            
            return IntPtr.Zero;
        }
    }
}