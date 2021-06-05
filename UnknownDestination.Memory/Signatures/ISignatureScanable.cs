namespace UnknownDestination.Memory.Signatures
{
    public interface ISignatureScanable
    {
        public byte?[] Pattern { get; }
        
        public bool Scan();
    }
}