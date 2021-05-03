using System;
using System.Linq;
using System.Collections.Generic;
using System.Numerics;
using Xunit;

using CTFLibrary;

namespace CTFLibrary.Math.Test
{
    public class RationalOpsTest
    {
        [Fact]
        public void ConstructorTest()
        {
            var a = new Rational(200, 300);
            Assert.Equal(2, a.Numerator);
            Assert.Equal(3, a.Denominator);
            var b = new Rational(-200, 300);
            Assert.Equal(-2, b.Numerator);
            Assert.Equal(3, b.Denominator);
            var c = new Rational(200, -300);
            Assert.Equal(-2, c.Numerator);
            Assert.Equal(3, c.Denominator);
        }
        [Fact]
        public void SubtractTest()
        {
            var a = new Rational(2, 3);
            var b = new Rational(5, 6);
            Assert.Equal(new Rational(1, -6), a - b);
        }
        [Fact]
        public void MultipleTest()
        {
            var a = new Rational(2, 3);
            var b = new Rational(5, 6);
            Assert.Equal(new Rational(5, 9), a * b);
        }
        [Fact]
        public void DivideTest()
        {
            var a = new Rational(2, 3);
            var b = new Rational(5, 6);
            Assert.Equal(new Rational(4, 5), a / b);
        }
        [Fact]
        public void EqualityTest()
        {
            var a = new Rational(2, 3);
            var b = new Rational(4, 6);
            Assert.True(a == b);
        }
        [Fact]
        public void CastTest()
        {
            var a = new Rational(2, 3);
            Assert.Equal((double)a, 2.0 / 3.0, 12);
        }
    }
}
