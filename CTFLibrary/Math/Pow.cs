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
        public static BigInteger Pow(this int value, int exp)
            => BigInteger.Pow(value, exp);
        public static BigInteger Pow(this long value, int exp)
            => BigInteger.Pow(value, exp);
        public static BigInteger Pow(this BigInteger value, int exp)
            => BigInteger.Pow(value, exp);
    }
}

