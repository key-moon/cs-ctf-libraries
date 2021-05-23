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
        public static BigInteger ModPow(this BigInteger value, int exp, BigInteger mod)
        {
            BigInteger pow = value;
            BigInteger res = 1;
            while (exp > 0)
            {
                if ((exp & 1) == 1) res = res * pow % mod;
                pow = pow * pow % mod;
                exp >>= 1;
            }
            return res;
        }
        public static BigInteger ModPow(this BigInteger value, long exp, BigInteger mod)
        {
            BigInteger pow = value;
            BigInteger res = 1;
            while (exp > 0)
            {
                if ((exp & 1) == 1) res = res * pow % mod;
                pow = pow * pow % mod;
                exp >>= 1;
            }
            return res;
        }
        public static BigInteger ModPow(this BigInteger value, BigInteger exp, BigInteger mod)
        {
            return BigInteger.ModPow(value, exp, mod);
        }
    }
}

