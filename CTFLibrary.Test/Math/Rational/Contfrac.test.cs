using System;
using System.Linq;
using System.Numerics;
using Xunit;

using CTFLibrary;

namespace CTFLibrary.Math.Test
{
    public class RationalContfracTest
    {
        [Fact]
        public void Test()
        {
            var contfrac = new Rational(12, 67).ToContfrac().ToArray();
            Assert.Equal(new BigInteger[] { 0, 5, 1, 1, 2, 2 }, contfrac);
        }
    }
}
