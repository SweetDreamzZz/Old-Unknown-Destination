namespace UnknownDestination.Memory.Enums.MemoryBasicInformation
{
    public enum State : uint
    {
        MemCommit = 0x1000,
        MemReserve = 0x2000,
        MemFree = 0x10000
    }
}