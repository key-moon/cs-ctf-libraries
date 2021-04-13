using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace CTFLibrary
{
    public partial struct Rational
    {
        public BigInteger Numerator { get; private set; }
        public BigInteger Denominator { get; private set; }

        public Rational(BigInteger numerator, BigInteger denominator)
        {
            var gcd = BigInteger.GreatestCommonDivisor(numerator, denominator);
            Numerator = numerator / gcd;
            Denominator = denominator / gcd;
        }
        private static Rational UncheckedBuild(BigInteger num, BigInteger den) { var res = new Rational(); res.Numerator = num; res.Denominator = den; return res; }
    }
}
