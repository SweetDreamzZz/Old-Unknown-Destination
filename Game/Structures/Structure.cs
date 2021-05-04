using System;

namespace softnaosu.Structures
{
    public abstract class Structure
    {
        protected IntPtr BaseAddress { get; }

        protected Structure(IntPtr baseAddress) => BaseAddress = baseAddress;
        
        // TODO: protected IntPtr GetPointer() <- Returns pointer to current structure
    }
}