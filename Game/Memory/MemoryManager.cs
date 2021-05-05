using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using softnaosu.Game.Enums;
using softnaosu.Game.Utils;

namespace softnaosu.Game.Memory
{
    public static class MemoryManager
    {
        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool ReadProcessMemory(IntPtr hProcess, 
            IntPtr lpBaseAddress,
            [Out] byte[] lpBuffer,
            uint dwSize,
            out IntPtr lpNumberOfBytesRead);
        
        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool WriteProcessMemory(IntPtr hProcess,
            IntPtr lpBaseAddress,
            byte[] lpBuffer,
            uint nSize,
            out IntPtr lpNumberOfBytesRead);
        
        [DllImport("kernel32.dll", SetLastError = true)]
        private static extern uint VirtualQueryEx(IntPtr hProcess,
            IntPtr lpAddress,
            out MemoryBasicInformation lpBuffer,
            uint dwLength);
        
        public static bool FindAddressBySignaturePattern(string pattern, out IntPtr address)
        {
            var signatureBytes = convertSignaturePatternToBytes(pattern);
            var memoryRegions = EnumerateMemoryRegions();

            foreach (var region in memoryRegions)
            {
                if (Extensions.BiggerThan(Global.Process?.MainModule?.BaseAddress ?? IntPtr.Zero, region.BaseAddress))
                    continue;

                var regionBytes = ReadBytes(region.BaseAddress, (uint)region.RegionSize);
                if (compareBytes(signatureBytes, regionBytes) is var offset && offset != IntPtr.Zero)
                {
                    address = Extensions.Add(region.BaseAddress, offset);

                    return true;
                }
            }
            
            address = IntPtr.Zero;

            return false;
        }
        
        public static int ReadInt32(IntPtr address) => BitConverter.ToInt32(ReadBytes(address, sizeof(int)), 0);

        public static float ReadSingle(IntPtr address) => BitConverter.ToSingle(ReadBytes(address, sizeof(float)), 0);

        public static double ReadDouble(IntPtr address) => BitConverter.ToDouble(ReadBytes(address, sizeof(double)), 0);

        public static bool ReadBool(IntPtr address) => BitConverter.ToBoolean(ReadBytes(address, sizeof(bool)), 0);
        
        public static string ReadString(IntPtr address, Encoding encoding = null)
        {
            encoding = encoding ?? Encoding.UTF8;
            
            var stringPointer = (IntPtr)ReadInt32(address);
            var stringLength = ReadInt32(stringPointer + 0x4) * (encoding.Equals(Encoding.UTF8) ? 2 : 1);

            return encoding.GetString(ReadBytes(stringPointer + 0x8, (uint)stringLength)).Replace("\0", string.Empty);
        }
        
        public static byte[] ReadBytes(IntPtr address, uint size)
        {
            var buffer = new byte[size];
            ReadProcessMemory(Global.Process.Handle, address, buffer, size, out var bytes);
            return buffer;
        }

        public static void Write(IntPtr address, byte[] buffer, uint size)
            => WriteProcessMemory(Global.Process.Handle, address, buffer, size, out var bytes);
        
        private static List<MemoryRegion> EnumerateMemoryRegions()
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

        private static byte?[] convertSignaturePatternToBytes(string pattern)
        {
            var chunks = pattern.Split(' ');
            var bytes = new byte?[chunks.Length];

            for (var i = 0; i < bytes.Length; i++)
            {
                var chunk = chunks[i];

                if (chunk == "??")
                    bytes[i] = null;
                else
                    bytes[i] = Convert.ToByte(chunk, 16);
            }

            return bytes;
        }

        private static IntPtr compareBytes(byte?[] signatureBytes, byte[] regionBytes)
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