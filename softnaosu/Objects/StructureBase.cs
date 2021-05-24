using System;
using softnaosu.Memory;

namespace softnaosu.Objects
{
    public class StructureBase
    {
        public IntPtr BaseAddress;

        protected static IntPtr ReadPointerAddress(IntPtr pointerAddress) => (IntPtr) MemoryManager.ReadInt32(pointerAddress);
        
        protected static IntPtr ReadPointerBaseAddress(IntPtr pointerAddress) => 
            (IntPtr)MemoryManager.ReadInt32(ReadPointerAddress(pointerAddress));
    }
}