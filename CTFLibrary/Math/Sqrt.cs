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
        public static bool Sqrt(this int value)
        {
            throw new NotImplementedException();
        }
        public static bool Sqrt(this long value)
        {
            throw new NotImplementedException();
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

