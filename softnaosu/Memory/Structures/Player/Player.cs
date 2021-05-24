using softnaosu.Memory.Serialization;
using softnaosu.Memory.Signatures;
using softnaosu.Memory.Structures.Player.Ruleset;
using softnaosu.Memory.Structures.Player.HitObjectManager;
using softnaosu.Objects;

namespace softnaosu.Memory.Structures.Player
{
    public class Player : StructureBase, IMemoryDeserializable
    {
        // 0x40
        public PlayerHitObjectManager HitObjectManager; 
        
        // Offset 0x60
        public PlayerRuleset Ruleset;
        
        public static Player Instance => GetPlayer();
        
        private static Player GetPlayer()
        {
            var baseAddress = ReadPointerBaseAddress(PlayerSignature.PointerAddress);

            var player = new Player
            {
                BaseAddress = baseAddress
            };
            using var reader = SerializationReader.FromMemoryRegion(baseAddress, player);
            player.ReadFromStream(reader);

            return player;
        }

        public int MemoryBlockSize { get; set; } = 0x60 + sizeof(int);
        
        public void ReadFromStream(SerializationReader reader)
        {
            reader.ReadBytes(0x40);

            HitObjectManager = reader.ReadStructure<PlayerHitObjectManager>();

            reader.ReadBytes(0x60 - (0x40 + sizeof(int)));

            Ruleset = reader.ReadStructure<PlayerRuleset>();
        }
    }
}