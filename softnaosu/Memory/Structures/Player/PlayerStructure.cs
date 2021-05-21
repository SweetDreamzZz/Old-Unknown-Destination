using softnaosu.Memory.Signatures;
using softnaosu.Utils;

namespace softnaosu.Memory.Structures.Player
{
    [Offset(0x7)]
    public class PlayerStructure : StructureBase
    {
        public RulesetStructure Ruleset;
        
        public static PlayerStructure Instance
        {
            get
            {
                var baseAddress = ReadStruct(PlayerSignature.PointerAddress);

                return new PlayerStructure
                {
                    BaseAddress = baseAddress,
                    
                    Ruleset = new RulesetStructure(Extensions.AddIntPtr(baseAddress,
                        Extensions.GetStructureOffset<RulesetStructure>()))
                };
            }
        }
    }
}