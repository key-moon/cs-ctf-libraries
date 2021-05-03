using System;
using System.Linq;
using System.Numerics;
using Xunit;

using CTFLibrary;

namespace CTFLibrary.Math.Test
{
    public class SqrtTest
    {
        [Fact]
        public void Test()
        {
            for (int i = 1; i < 10000; i++)
            {
                var a = ((int)i).Sqrt();
                var b = ((long)i).Sqrt();
                var c = ((BigInteger)i).Sqrt();
                Assert.True(a * a <= i);
                Assert.True(b * b <= i);
                Assert.True(c * c <= i);
                Assert.True(i < (a + 1) * (a + 1));
                Assert.True(i < (b + 1) * (b + 1));
                Assert.True(i < (c + 1) * (c + 1));
            }
        }
    }
}
