using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Numerics;
using System.Text;

namespace CTFLibrary
{
    public partial struct Rational
    {
        public static Rational operator +(Rational a, Rational b)
        {
            var gcd = BigInteger.GreatestCommonDivisor(a.Denominator, b.Denominator);
            var divedA = a.Denominator / gcd;
            var divedB = b.Denominator / gcd;
            return new Rational(a.Numerator * divedB + b.Numerator * divedA, divedA * b.Denominator);
        }
        public static Rational operator -(Rational val) => UncheckedBuild(-val.Numerator, val.Denominator);
        public static Rational operator -(Rational a, Rational b) => a + -b;
        public static Rational operator *(Rational a, Rational b) => new(a.Numerator * b.Numerator, a.Denominator * b.Denominator);
        public static Rational operator /(Rational a, Rational b) => new(a.Numerator * b.Denominator, a.Denominator * b.Numerator);
        public static bool operator ==(Rational a, Rational b) => (a.Denominator == b.Denominator && a.Numerator == b.Numerator);
        public static bool operator !=(Rational a, Rational b) => !(a == b);
        public static implicit operator Rational(int a) => new(a, 1);
        public static implicit operator Rational(long a) => new(a, 1);
        public static implicit operator Rational(BigInteger a) => new(a, 1);
        public static implicit operator double(Rational a)
        {
            var num = a.Numerator;
            var den = a.Denominator;
            while (long.MaxValue <= num || long.MaxValue <= den)
            {
                num /= 2;
                den /= 2;
            }
            return (double)num / (double)den;
        }

        public override bool Equals([NotNullWhen(true)] object obj)
        {
            return base.Equals(obj);
        }
        public override int GetHashCode() => Numerator.GetHashCode() ^ Denominator.GetHashCode();
    }
}
