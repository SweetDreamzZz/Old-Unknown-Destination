using System;
using softnaosu.Memory.Structures.Beatmap;
using softnaosu.Utils;

namespace softnaosu.Memory.Signatures
{
    public class BeatmapSignature : SignatureBase
    {
        public static IntPtr PointerAddress = IntPtr.Zero;
        
        // EB 0C DD 1C 24 83 3D
        private static readonly byte?[] Pattern = { 0xEB, 0x0C, 0xDD, 0x1C, 0x24, 0x83, 0x3D };

        public static bool Scan() => ScanSignature(Pattern, Extensions.GetStructureOffset<BeatmapStructure>(), out PointerAddress);
    }
}