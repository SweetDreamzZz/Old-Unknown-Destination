using System;

namespace softnaosu.Memory.Structures
{
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Class)]
    public class OffsetAttribute : Attribute
    {
        public IntPtr Offset;

        public OffsetAttribute(int offset) => Offset = (IntPtr) offset;
    }
}