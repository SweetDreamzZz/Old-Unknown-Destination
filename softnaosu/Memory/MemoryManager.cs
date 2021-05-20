using System;
using System.Runtime.InteropServices;
using System.Text;
using softnaosu.Objects;

namespace softnaosu.Memory
{
    public class MemoryManager
    {
        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern int VirtualQueryEx(IntPtr hProcess,
            IntPtr lpAddress,
            out MemoryBasicInformation lpBuffer,
            uint dwLength);
        
        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool ReadProcessMemory(IntPtr hProcess,
            IntPtr lpBaseAddress,
            [Out] byte[] lpBuffer,
            int dwSize,
            out IntPtr lpNumberOfBytesRead); 
        
        public readonly IntPtr HandleProcess;

        public MemoryManager(IntPtr hProcess) => HandleProcess = hProcess;

        public int ReadInt32(IntPtr address) => BitConverter.ToInt32(ReadBytes(address, sizeof(int)), 0);

        public float ReadSingle(IntPtr address) => BitConverter.ToSingle(ReadBytes(address, sizeof(float)), 0);

        public double ReadDouble(IntPtr address) => BitConverter.ToDouble(ReadBytes(address, sizeof(double)), 0);
        
        public bool ReadBool(IntPtr address) => BitConverter.ToBoolean(ReadBytes(address, sizeof(bool)), 0);

        public string ReadString(IntPtr address, Encoding encoding = null)
        {
            encoding = encoding ?? Encoding.UTF8;

            var pointer = (IntPtr)ReadInt32(address);
            var length = ReadInt32(pointer + 0x4) * (encoding.Equals(Encoding.UTF8) ? 2 : 1);

            return encoding.GetString(ReadBytes(pointer + 0x8, length)).Replace("\0", string.Empty);
        }

        public byte[] ReadBytes(IntPtr address, int size)
        {
            var buffer = new byte[size];
            ReadProcessMemory(HandleProcess, address, buffer, size, out var bytes);

            return buffer;
        }
    }
}