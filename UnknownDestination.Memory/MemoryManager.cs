using System;
using System.Runtime.InteropServices;
using UnknownDestination.Shared;

namespace UnknownDestination.Memory
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
        
        public static byte[] ReadBytes(IntPtr address, uint size)
        {
            var buffer = new byte[size];
            ReadProcessMemory(Global.Process.Handle, address, buffer, size, out var bytes);

            return buffer;
        }
    }
}