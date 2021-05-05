using System;
using System.Reflection;

namespace softnaosu.Game.Memory
{
    [AttributeUsage(AttributeTargets.Field)]
    public class OffsetAttribute : Attribute
    {
        public readonly IntPtr Offset;

        public OffsetAttribute(int offset) => Offset = (IntPtr) offset;
    }
}