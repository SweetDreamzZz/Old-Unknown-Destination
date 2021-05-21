using System;
using System.IO;
using System.Text;

namespace softnaosu.Memory.Serialization
{
    public class SerializationReader : BinaryReader
    {
        private readonly bool _needDispose;

        public SerializationReader(Stream s, bool disposeStreamOnReaderDispose = false) : base(s, Encoding.UTF8)
        {
            _needDispose = disposeStreamOnReaderDispose;
        }
        
        public static SerializationReader FromMemoryRegion(IntPtr memoryPointer, int length)
        {
            var bytes = MemoryManager.ReadBytes(memoryPointer, length);
            var stream = new MemoryStream(bytes);
            return new SerializationReader(stream, true);
        }

        public static SerializationReader FromMemoryRegion(IntPtr memoryPointer, IMemoryDeserializable obj)
        {
            return FromMemoryRegion(memoryPointer, obj.GetLength());
        }

        public override string ReadString() => ReadString(Encoding.UTF8);

        public string ReadString(Encoding encoding)
        {
            var pointer = (IntPtr)ReadInt32();
            var length = MemoryManager.ReadInt32(pointer + 0x4) * (encoding.Equals(Encoding.UTF8) ? 2 : 1);

            return encoding.GetString(MemoryManager.ReadBytes(pointer + 0x8, length)).Replace("\0", string.Empty);
        }

        public T ReadOsuObject<T>() where T : IMemoryDeserializable, new()
        {
            return ReadOsuObject(new T());
        }
        
        public T ReadOsuObject<T>(T t) where T : IMemoryDeserializable, new()
        {
            t.ReadFromStream(this);
            return t;
        }

        public new void Dispose()
        {
            if(_needDispose)
                BaseStream.Dispose();
        }
    }
}