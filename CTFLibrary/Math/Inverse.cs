using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CTFLibrary
{
    public static partial class MyMath
    {
        public static BigInteger Inverse(this BigInteger a, BigInteger mod)
        {
            BigInteger div, p = mod, x1 = 1, y1 = 0, x2 = 0, y2 = 1;
            while (true)
            {
                if (p == 1) return x2 + mod; div = BigInteger.DivRem(a, p, out a); x1 -= x2 * div; y1 -= y2 * div;
                if (a == 1) return x1 + mod; div = BigInteger.DivRem(p, a, out p); x2 -= x1 * div; y2 -= y1 * div;
            }
        }
    }
}

