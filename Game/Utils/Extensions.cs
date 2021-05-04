using System;

namespace softnaosu.Game.Utils
{
    public class Extensions
    {
        public static bool BiggerThan(IntPtr lhs, IntPtr rhs) => (int) lhs > (int) rhs;

        public static IntPtr Add(IntPtr lhs, IntPtr rhs) => (IntPtr) ((int) lhs + (int) rhs);
    }
}