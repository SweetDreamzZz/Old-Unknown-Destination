using System;
using UnknownDestination.Memory.Enums.MemoryBasicInformation;

namespace UnknownDestination.Memory.Objects
{
    public struct MemoryBasicInformation
    {
        public IntPtr BaseAddress;

        public IntPtr AllocationBase;

        public Protect AllocationProtect;
        
        public IntPtr RegionSize;

        public State State;

        public Protect Protect;

        public Enums.MemoryBasicInformation.Type Type;
    }
}