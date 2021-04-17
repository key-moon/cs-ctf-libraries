using System;
using System.Numerics;
using Xunit;

using CTFLibrary;

namespace CTFLibrary.Math.Test
{
    public class InverseTest
    {
        [Fact]
        public void Test()
        {
            var p = BigInteger.Pow(2, 127) - 1;
            var m = (BigInteger)int.MaxValue;
            Assert.Equal(1, (m.Inverse(p) * m) % p);
        }
    }
}
