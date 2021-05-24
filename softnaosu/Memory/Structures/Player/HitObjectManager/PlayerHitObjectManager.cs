using System;
using System.Collections.Generic;
using softnaosu.Memory.Serialization;
using softnaosu.Objects;
using softnaosu.Utils;

namespace softnaosu.Memory.Structures.Player.HitObjectManager
{
    public class PlayerHitObjectManager : StructureBase, IMemoryDeserializable
    {
        // Offset 0x48
        public HitObjects HitObjects;

        public int MemoryBlockSize { get; set; } = 0x48 + sizeof(int);

        public void ReadFromStream(SerializationReader reader)
        {
            reader.ReadBytes(0x48);

            HitObjects = reader.ReadStructure<HitObjects>();
        }
    }
}