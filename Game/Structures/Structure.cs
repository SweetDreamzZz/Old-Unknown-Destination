using System;
using softnaosu.Game.Memory;

namespace softnaosu.Game.Structures
{
    public class Structure
    {
        protected readonly IntPtr BaseAddress;

        protected Structure(IntPtr baseAddress) => BaseAddress = baseAddress;

        protected IntPtr GetPointer() => (IntPtr) MemoryManager.ReadInt32(BaseAddress);
    }
}