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
        public static int Sqrt(this int value) => (int)Math.Sqrt(value);
        public static long Sqrt(this long value)
        {
            var sq = (long)Math.Round(Math.Sqrt(value));
            while (value < sq * sq) sq--;
            return sq;
        }
        // TODO: はやいやつを実装する
        public static BigInteger Sqrt(this BigInteger n)
        {
            if (n == 0) return BigInteger.Zero;

            static bool isSqrt(BigInteger n, BigInteger root)
            {
                BigInteger lowerBound = root * root;
                BigInteger upperBound = (root + 1) * (root + 1);

                return (n >= lowerBound && n < upperBound);
            }

            if (n > 0)
            {
                int bitLength = (int)(Math.Ceiling(BigInteger.Log(n, 2)));
                BigInteger root = BigInteger.One << (bitLength / 2);

                while (!isSqrt(n, root))
                {
                    root += n / root;
                    root /= 2;
                }
                return root;
            }

            throw new Exception();
        }
    }
}

