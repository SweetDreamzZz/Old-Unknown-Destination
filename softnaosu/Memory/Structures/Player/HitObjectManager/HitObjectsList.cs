using System;
using System.Collections.Generic;
using softnaosu.Memory.Serialization;
using softnaosu.Memory.Structures.Player.HitObjectManager.Objects;
using softnaosu.Objects;

namespace softnaosu.Memory.Structures.Player.HitObjectManager
{
    public class HitObjectsList : ListStructure<HitObject>, IMemoryDeserializable
    {
        public int MemoryBlockSize { get; set; }

        public void ReadFromStream(SerializationReader reader)
        {
            reader.ReadBytes(0x8); // _items first element

            for (var i = 0; i < ListSize; i++)
            {
                var hitObject = reader.ReadStructure<HitObject>();

                ListItems.Add(hitObject);
            }
        }
    }
}