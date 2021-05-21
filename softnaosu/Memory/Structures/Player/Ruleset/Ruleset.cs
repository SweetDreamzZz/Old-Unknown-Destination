using System;
using System.Numerics;
using softnaosu.Utils;

namespace softnaosu.Memory.Structures.Player
{
    [Offset(0x60)]
    public class RulesetStructure
    {
        public MousePosition MousePosition;

        public RulesetStructure(IntPtr pointer)
        {
            var baseAddress = (IntPtr)MemoryManager.ReadInt32(pointer);
            
            MousePosition = new MousePosition
            {
                X = MemoryManager.ReadSingle(Extensions.AddIntPtr(baseAddress,
                    Extensions.GetFieldOffset<MousePosition>("X"))),
                
                Y = MemoryManager.ReadSingle(Extensions.AddIntPtr(baseAddress,
                    Extensions.GetFieldOffset<MousePosition>("Y"))),
            };
        }
    }
}