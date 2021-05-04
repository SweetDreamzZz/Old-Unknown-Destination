using System;

namespace softnaosu.Game.Memory
{
    public struct MemoryBasicInformation
    {
        public IntPtr BaseAddress;
        public IntPtr AllocationBase;
        public Protect AllocationProtect;
        public IntPtr RegionSize;
        public State State;
        public Protect Protect;
        public Type Type;
    }
    
    public class MemoryRegion
    {
        public IntPtr BaseAddress { get; private set; }
        public IntPtr AllocationBase { get; private set; }
        public Protect AllocationProtect { get; private set; }
        public IntPtr RegionSize { get; private set; }
        public State State { get; private set; }
        public Protect Protect { get; private set; }
        public Type Type { get; private set; }
        
        public MemoryRegion(MemoryBasicInformation mbi)
        {
            BaseAddress = mbi.BaseAddress;
            AllocationBase = mbi.AllocationBase;
            AllocationProtect = mbi.AllocationProtect;
            RegionSize = mbi.RegionSize;
            State = mbi.State;
            Protect = mbi.Protect;
            Type = mbi.Type;
        }
    }

    public enum Protect : uint
    {
        PageNoAccess = 0x00000001,
        PageReadOnly = 0x00000002,
        PageReadWrite = 0x00000004,
        PageWriteCopy = 0x00000008,
        PageExecute =  0x00000010,
        PageExecuteRead = 0x00000020,
        PageExecuteReadWrite = 0x00000040,
        PageExecuteWriteCopy = 0x00000080,
        PageGuard = 0x00000100,
        PageNoCache = 0x00000200,
        PageWriteCombine = 0x00000400
    }

    public enum State : uint
    {
        MemCommit = 0x1000,
        MemReserve = 0x2000,
        MemFree = 0x10000
    }

    public enum Type : uint
    {
        MemPrivate = 0x20000,
        MemMapped = 0x40000,
        MemImage = 0x1000000
    }
}