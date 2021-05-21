using System;

namespace softnaosu.Memory.Structures
{
    public class StructureBase
    {
        public IntPtr BaseAddress;
        
        protected static IntPtr ReadStruct(IntPtr pointer) => 
            (IntPtr)MemoryManager.ReadInt32((IntPtr)MemoryManager.ReadInt32(pointer));
    }
}