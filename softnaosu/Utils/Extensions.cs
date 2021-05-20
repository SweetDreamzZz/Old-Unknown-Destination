using System;
using System.Linq;

namespace softnaosu.Utils
{
    public class Extensions
    {
        public static IntPtr AddIntPtr(IntPtr lhs, IntPtr rhs) => (IntPtr) ((int) lhs + (int) rhs);
    }
}