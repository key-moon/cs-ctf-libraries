using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace CTFLibrary
{
    public static partial class Util
    {
        public static bool ChMax<T>(ref T a, T b) where T : IComparable<T> { if (a.CompareTo(b) >= 0) return false; a = b; return true; }
        public static bool ChMin<T>(ref T a, T b) where T : IComparable<T> { if (a.CompareTo(b) <= 0) return false; a = b; return true; }
    }
}
