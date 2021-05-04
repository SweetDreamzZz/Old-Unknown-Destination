using System;
using softnaosu.Game.Enums;

namespace softnaosu.Game.Memory
{
    public struct MemoryBasicInformation
    {
        public readonly IntPtr BaseAddress;
        public readonly IntPtr AllocationBase;
        public readonly Protect AllocationProtect;
        public readonly IntPtr RegionSize;
        public readonly State State;
        public readonly Protect Protect;
        public readonly Enums.Type Type;
    }
    
    public class MemoryRegion
    {
        public readonly IntPtr BaseAddress;
        public readonly IntPtr AllocationBase;
        public readonly Protect AllocationProtect;
        public readonly IntPtr RegionSize;
        public readonly State State;
        public readonly Protect Protect;
        public readonly Enums.Type Type;
        
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
    
}