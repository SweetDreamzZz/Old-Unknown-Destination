using System;

namespace softnaosu.Game.Signatures
{
    public static class Signature
    {
        public static readonly SignatureBase Beatmap = new SignatureBase
        {
            Pattern = "EB 0C DD 1C 24 83 3D",
            Offset = (IntPtr) 0x7
        };

        public static readonly SignatureBase Player = new SignatureBase
        {
            Pattern = "FF 50 0C 8B D8 8B 15",
            Offset = (IntPtr)0x7
        };
    };
}