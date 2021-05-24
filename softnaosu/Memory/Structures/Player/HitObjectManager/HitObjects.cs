using System;
using softnaosu.Memory.Serialization;
using softnaosu.Memory.Structures.Player.HitObjectManager.Objects;
using softnaosu.Objects;
using softnaosu.Utils;

namespace softnaosu.Memory.Structures.Player.HitObjectManager
{
    public class HitObjects : StructureBase, IMemoryDeserializable
    {
        // 0x4
        public HitObjectsList HitObjectsList;

        // Offset 0xC
        public int HitObjectsCount;

        public int MemoryBlockSize { get; set; } = 0x4 + sizeof(int);

        public void ReadFromStream(SerializationReader reader)
        {
            reader.ReadBytes(0x4);

            HitObjectsCount = MemoryManager.ReadInt32(Extensions.AddIntPtr(BaseAddress,(IntPtr) 0xC));
            HitObjectsList = reader.ReadList<HitObjectsList, HitObject>(HitObjectsCount);
        }
    }
}