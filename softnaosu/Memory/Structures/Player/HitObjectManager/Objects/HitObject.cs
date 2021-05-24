using System.Numerics;
using softnaosu.Memory.Serialization;
using softnaosu.Objects;

namespace softnaosu.Memory.Structures.Player.HitObjectManager.Objects
{
    public class HitObject : StructureBase, IMemoryDeserializable
    {
        // 0x8C
        public Vector2 BasePosition;

        public int MemoryBlockSize { get; set; } = 0x8C + sizeof(float) * 2;

        public void ReadFromStream(SerializationReader reader)
        {
            reader.ReadBytes(0x8C);

            BasePosition = reader.ReadVector2();
        }
    }
}