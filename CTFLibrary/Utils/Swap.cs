using System;
using System.Collections.Generic;
using System.Text;

namespace CTFLibrary
{
    public static partial class Util
    {
        public static void Swap<T>(ref T a, ref T b) => (a, b) = (b, a);
    }
}
