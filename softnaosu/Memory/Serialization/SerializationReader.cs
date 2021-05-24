using System;
using System.IO;
using System.Numerics;
using System.Text;
using softnaosu.Objects;

namespace softnaosu.Memory.Serialization
{
    
    /**
     * huge thanks to Keijia <3
     */
    
    public class SerializationReader : BinaryReader
    {
        private readonly bool _needDispose;
        
        public static SerializationReader FromMemoryRegion(IntPtr address, IMemoryDeserializable obj)
        {
            return FromMemoryRegion(address, obj.MemoryBlockSize);
        }
        
        private static SerializationReader FromMemoryRegion(IntPtr address, int size)
        {
            var bytes = MemoryManager.ReadBytes(address, size);
            var stream = new MemoryStream(bytes);
            
            return new SerializationReader(stream, true);
        }
        
        private SerializationReader(Stream s, bool disposeStreamOnReaderDispose = false) : base(s, Encoding.UTF8)
        {
            _needDispose = disposeStreamOnReaderDispose;
        }

        public T ReadList<T, R>(int size) 
            where R : StructureBase, IMemoryDeserializable
            where T : ListStructure<R>, IMemoryDeserializable, new()
        {
            return ReadList<T, R>(new T(), size);
        }
        
        private T ReadList<T, R>(T o, int size) 
            where R : StructureBase, IMemoryDeserializable
            where T : ListStructure<R>, IMemoryDeserializable, new()
        {
            o.BaseAddress = (IntPtr) ReadInt32();

            o.ListSize = size;
            o.MemoryBlockSize = 0x8 * o.ListSize + 0x4;
            
            using var reader = FromMemoryRegion(o.BaseAddress, o);
            o.ReadFromStream(reader);
            
            return o;
        }
        
        public Vector2 ReadVector2()
        {
            var x = ReadSingle();
            var y = ReadSingle();

            return new Vector2(x, y);
        }

        public T ReadStructure<T>() where T : StructureBase, IMemoryDeserializable, new()
        {
            return ReadStructure(new T());
        }

        private T ReadStructure<T>(T o) where T : StructureBase, IMemoryDeserializable
        {
            o.BaseAddress = (IntPtr) ReadInt32();

            using var reader = FromMemoryRegion(o.BaseAddress, o);
            o.ReadFromStream(reader);

            return o;
        }

        public override string ReadString() => ReadString(Encoding.UTF8);       
        
        private string ReadString(Encoding encoding)
        {
            var pointer = (IntPtr) ReadInt32();
            var length = MemoryManager.ReadInt32(pointer + 0x4) * (encoding.Equals(Encoding.UTF8) ? 2 : 1);

            return encoding.GetString(MemoryManager.ReadBytes(pointer + 0x8, length)).Replace("\0", string.Empty);
        }

        public new void Dispose()
        {
            if (_needDispose) BaseStream.Dispose();
        }
    }
}