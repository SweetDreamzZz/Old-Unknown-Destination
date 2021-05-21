using System;
using System.Reflection;
using softnaosu.Memory.Structures;

namespace softnaosu.Utils
{
    public class Extensions
    {
        public static bool BiggerThanIntPtr(IntPtr lhs, IntPtr rhs) => (int) lhs > (int) rhs;
        
        public static IntPtr AddIntPtr(IntPtr lhs, IntPtr rhs) => (IntPtr) ((int) lhs + (int) rhs);

        public static IntPtr GetFieldOffset<T>(string name) =>
            typeof(T).GetField(name).GetCustomAttribute<OffsetAttribute>().Offset;

        public static IntPtr GetStructureOffset<T>() => typeof(T).GetCustomAttribute<OffsetAttribute>().Offset;
    }
}