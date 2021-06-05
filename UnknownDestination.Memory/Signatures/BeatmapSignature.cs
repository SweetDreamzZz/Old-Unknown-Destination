namespace UnknownDestination.Memory.Signatures
{
    public class BeatmapSignature : SignatureBase, ISignatureScanable
    {
        public byte?[] Pattern { get; } = { 0xEB, 0x0C, 0xDD, 0x1C, 0x24, 0x83, 0x3D };

        public bool Scan() => SignatureScanner.Scan(Pattern, Pattern.Length, out Address);
    }
    
}