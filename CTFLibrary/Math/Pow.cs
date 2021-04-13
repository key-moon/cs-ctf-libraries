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
        public static BigInteger Pow(this BigInteger value, int exp)
        {
            return BigInteger.Pow(value, exp);
        }
        public static BigInteger Pow(this BigInteger value, long exp)
        {
            BigInteger pow = value;
            BigInteger res = 1;
            while (exp > 0)
            {
                if ((exp & 1) == 1) res *= pow;
                pow *= pow;
                exp >>= 1;
            }
            return res;
        }
        public static BigInteger Pow(this BigInteger value, BigInteger exp)
        {
            var expArr = exp.ToByteArray();
            BigInteger pow = value;
            BigInteger res = 1;
            for (int i = 0; i < expArr.Length; i++)
            {
                var chunk = expArr[i];
                for (int j = 0; j < 8; j++)
                {
                    if ((chunk & 1) == 1) res *= pow;
                    pow *= pow;
                    chunk >>= 1;
                }
            }
            return res;
        }
    }
}

