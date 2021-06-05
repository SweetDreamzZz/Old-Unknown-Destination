using System;

namespace UnknownDestination.Memory.Structures
{
    public interface IMarshalReadable
    {
        public void Read(IntPtr baseAddress);
    }
}