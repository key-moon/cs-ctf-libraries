using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace CTFLibrary
{
    public partial struct Rational
    {
        /// <summary>
        /// a_0+1/(a_1+1/(a_2+1/a_3+...))
        /// </summary>
        public IEnumerable<BigInteger> ToContfrac()
        {
            var num = Numerator;
            var den = Denominator;
            while (den != 0)
            {
                yield return BigInteger.DivRem(num, den, out BigInteger rem);
                (num, den) = (den, rem);
            }
        }
    }
}
