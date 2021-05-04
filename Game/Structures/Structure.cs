using System;
using softnaosu.Game.Memory;

namespace softnaosu.Structures
{
    public class Structure
    {
        protected IntPtr BaseAddress { get; }

        protected Structure(IntPtr baseAddress) => BaseAddress = baseAddress;

        protected IntPtr GetPointer() => (IntPtr) MemoryManager.ReadInt32(BaseAddress);
    }
}