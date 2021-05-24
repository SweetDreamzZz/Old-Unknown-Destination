namespace softnaosu.Memory.Serialization
{
    public interface IMemoryDeserializable
    {
        public int MemoryBlockSize { get; set; }
        
        public void ReadFromStream(SerializationReader reader);
    }
}