namespace softnaosu.Memory.Serialization
{
    public interface IMemoryDeserializable
    {
        int GetLength();
        void ReadFromStream(SerializationReader reader);
    }
}