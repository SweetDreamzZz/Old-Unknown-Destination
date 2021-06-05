using System;

namespace UnknownDestination.Memory.Extensions
{
    public static class Extensions
    {
        public static bool BiggerThan(this IntPtr pointer, IntPtr value) => (int) pointer > (int) value;

        public static IntPtr Add(this IntPtr pointer, IntPtr value) => (IntPtr)((int) pointer + (int)value);
        
        public static IntPtr Add(this IntPtr pointer, int value) => (IntPtr)((int) pointer + value);
    }
}