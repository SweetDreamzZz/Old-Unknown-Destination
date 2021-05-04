using System;

namespace softnaosu.Game.Memory
{
    [AttributeUsage(AttributeTargets.Field)]
    public class OffsetAttribute : Attribute
    {
        public readonly IntPtr Offset;
        
        public OffsetAttribute(IntPtr offset)
        {
            Offset = offset;
        }

        public OffsetAttribute(int offset)
        {
            Offset = (IntPtr) offset;
        }
    }
}