using System;
using softnaosu.Objects;

namespace softnaosu.Memory.Signatures
{
    public class PlayerSignature : SignatureBase
    {
        public static IntPtr PointerAddress = IntPtr.Zero;
        
        // FF 50 0C 8B D8 8B 15
        private static readonly byte?[] Pattern = { 0xFF, 0x50, 0x0C, 0x8B, 0xD8, 0x8B, 0x15 };

        private const int Offset = 0x7;

        public static bool Scan() => ScanSignature(Pattern, (IntPtr)Offset, out PointerAddress);
    }
}