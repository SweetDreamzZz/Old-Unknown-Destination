using softnaosu.Memory.Serialization;
using softnaosu.Objects;

namespace softnaosu.Memory.Structures.Player.Ruleset
{
    public class PlayerRuleset : StructureBase, IMemoryDeserializable
    {
        public MousePosition MousePosition;

        private MousePosition GetMousePosition()
        {
            var mousePosition = new MousePosition();
            using (var reader = SerializationReader.FromMemoryRegion(BaseAddress, mousePosition))
            {
                mousePosition.ReadFromStream(reader);
            }

            return mousePosition;
        }
        
        public int MemoryBlockSize { get; set; } = sizeof(int);

        public void ReadFromStream(SerializationReader reader)
        {
            MousePosition = GetMousePosition();
        }
    }
}