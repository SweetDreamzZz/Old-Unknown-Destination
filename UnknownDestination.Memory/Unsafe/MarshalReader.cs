using System;
using System.Runtime.InteropServices;
using System.Text;
using UnknownDestination.Memory.Extensions;

namespace UnknownDestination.Memory.Unsafe
{
    public static class MarshalReader
    {
        public static byte[] ReadBytes(IntPtr address, int size)
        {
            var bytes = new byte[size];
            Marshal.Copy(address, bytes, 0, size);

            return bytes;
        }

        public static IntPtr ReadIntPtr(IntPtr address) => Marshal.ReadIntPtr(address);
        
        public static short ReadInt16(IntPtr address) => BitConverter.ToInt16(ReadBytes(address, sizeof(short)), 0);
        
        public static int ReadInt32(IntPtr address) => BitConverter.ToInt32(ReadBytes(address, sizeof(int)), 0);
        
        public static long ReadInt64(IntPtr address) => BitConverter.ToInt32(ReadBytes(address, sizeof(long)), 0);
        
        public static float ReadSingle(IntPtr address) => BitConverter.ToInt32(ReadBytes(address, sizeof(float)), 0);
        
        public static double ReadDouble(IntPtr address) => BitConverter.ToInt32(ReadBytes(address, sizeof(double)), 0);

        public static string ReadString(IntPtr address) => ReadString(address, Encoding.UTF8);
        
        private static string ReadString(IntPtr address, Encoding encoding)
        {
            var pointer = ReadIntPtr(address);

            var length = ReadInt32(pointer.Add(0x4)) * (encoding.Equals(Encoding.UTF8) ? 2 : 1); 
            
            return encoding.GetString(ReadBytes(pointer.Add(0x8), length)).Replace("\0", string.Empty);
        }
    }
}