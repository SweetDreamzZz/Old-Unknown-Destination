using System;
using System.Diagnostics;
using System.Text;

namespace softnaosu.Game.Memory
{
    public class Memory : MemoryManager
    {
        public Memory(Process process) => Process = process;

        public int ReadInt32(IntPtr address) => BitConverter.ToInt32(ReadMemory(address, sizeof(int)), 0);

        public float ReadFloat(IntPtr address) => BitConverter.ToSingle(ReadMemory(address, sizeof(float)), 0);

        public bool ReadBool(IntPtr address) => BitConverter.ToBoolean(ReadMemory(address, sizeof(bool)), 0);

        public string ReadString(IntPtr address, Encoding encoding = null)
        {
            encoding = encoding ?? Encoding.UTF8;

            // length = Pointer + 0x4 offset
            // data = Pointer + 0x8 offset
            
            var stringPointer = (IntPtr)ReadInt32(address);
            var stringLength = ReadInt32(stringPointer + 0x4) * (encoding == Encoding.UTF8 ? 2 : 1);
            var stringData = ReadMemory(stringPointer + 0x8, (uint)stringLength);

            return encoding.GetString(stringData).Replace("\0", string.Empty);
        }
    }
}