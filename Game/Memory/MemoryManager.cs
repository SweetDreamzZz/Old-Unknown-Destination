using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace softnaosu.Game.Memory
{
    public class MemoryManager
    {
        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool ReadProcessMemory(IntPtr hProcess, 
            IntPtr lpBaseAddress,
            [Out] byte[] lpBuffer,
            uint dwSize,
            out IntPtr lpNumberOfBytesRead);

        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool WriteProcessMemory(IntPtr hProcess,
            IntPtr lpBaseAddress,
            byte[] lpBuffer,
            uint nSize,
            out IntPtr lpNumberOfBytesRead);
        
        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern uint VirtualQueryEx(IntPtr hProcess,
            IntPtr lpAddress,
            out MemoryBasicInformation lpBuffer,
            uint dwLength);
        
        public Process Process;

        public void FindAddressBySignaturePattern(string pattern, out IntPtr address)
        {
            var signatureBytes = convertSignaturePatternToBytes(pattern);
            var memoryRegions = EnumerateMemoryRegions();

            foreach (var region in memoryRegions)
            {
                if ((int)Process.MainModule.BaseAddress > (int)region.BaseAddress)
                    continue;

                var regionBytes = ReadMemory(region.BaseAddress, (uint)region.RegionSize);
                if (compareBytes(signatureBytes, regionBytes) is var offset && offset != IntPtr.Zero)
                {
                    address = (IntPtr)((int)region.BaseAddress + (int)offset);
                }
            }
            
            address = IntPtr.Zero;
        }

        public byte[] ReadMemory(IntPtr address, uint size)
        {
            var buffer = new byte[size];
            ReadProcessMemory(Process.Handle, address, buffer, size, out var bytes);
            return buffer;
        }

        public void WriteMemory(IntPtr address, byte[] buffer, uint size)
            => WriteProcessMemory(Process.Handle, address, buffer, size, out var bytes);

        private List<MemoryRegion> EnumerateMemoryRegions()
        {
            var memoryRegions = new List<MemoryRegion>();
            var currentAddress = IntPtr.Zero;
            
            while (VirtualQueryEx(Process.Handle,
                currentAddress,
                out var mbi,
                (uint) Marshal.SizeOf(typeof(MemoryBasicInformation))) != 0)
            {
                if (mbi.State != State.MemFree && !mbi.Protect.HasFlag(Protect.PageGuard))
                {
                    memoryRegions.Add(new MemoryRegion(mbi));
                }
                
                currentAddress = (IntPtr)(mbi.BaseAddress.ToInt32() + mbi.RegionSize.ToInt32());
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