using System;
using System.Reflection;
using softnaosu.Game.Memory;

namespace softnaosu.Game.Utils
{
    public class Extensions
    {
        public static bool BiggerThan(IntPtr lhs, IntPtr rhs) => (int) lhs > (int) rhs;

        public static IntPtr Add(IntPtr lhs, IntPtr rhs) => (IntPtr) ((int) lhs + (int) rhs);
        
        public static IntPtr GetFieldOffset<T>(string fieldName) => 
            typeof(T).GetField(fieldName).GetCustomAttribute<OffsetAttribute>().Offset;
    }
}