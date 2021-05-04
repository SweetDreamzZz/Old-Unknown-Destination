using System;
using System.Runtime.InteropServices;
using System.Text;

namespace softnaosu.Game.Memory
{
    public static class MemoryManager
    {
        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool ReadProcessMemory(IntPtr hProcess, 
            IntPtr lpBaseAddress,
            [Out, MarshalAs(UnmanagedType.AsAny)] out object lpBuffer,
            uint dwSize,
            out IntPtr lpNumberOfBytesRead);
        
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

        public static T Read<T>(IntPtr address) => (T) ReadObject(address, (uint) Marshal.SizeOf(typeof(T)));

        public static int ReadInt32(IntPtr address) => BitConverter.ToInt32(Read(address, sizeof(int)), 0);

        public static float ReadFloat(IntPtr address) => BitConverter.ToSingle(Read(address, sizeof(float)), 0);

        public static bool ReadBool(IntPtr address) => BitConverter.ToBoolean(Read(address, sizeof(bool)), 0);
        
        public static string ReadString(IntPtr address, Encoding encoding = null)
        {
            encoding = encoding ?? Encoding.UTF8;
            
            var stringPointer = (IntPtr)ReadInt32(address);
            var stringLength = ReadInt32(stringPointer + 0x4) * (encoding.Equals(Encoding.UTF8) ? 2 : 1);

            return encoding.GetString(Read(stringPointer + 0x8, (uint)stringLength)).Replace("\0", string.Empty);
        }
        
        public static object ReadObject(IntPtr address, uint size)
        {
            ReadProcessMemory(Global.Process.Handle, address, out var buffer, size, out var bytes);
            return buffer;
        }
        
        public static byte[] Read(IntPtr address, uint size)
        {
            var buffer = new byte[size];
            ReadProcessMemory(Global.Process.Handle, address, buffer, size, out var bytes);
            return buffer;
        }

        public static void Write(IntPtr address, byte[] buffer, uint size)
            => WriteProcessMemory(Global.Process.Handle, address, buffer, size, out var bytes);
    }
}