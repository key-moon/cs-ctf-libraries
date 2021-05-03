using System;
using System.Linq;
using System.Numerics;
using Xunit;

using CTFLibrary;

namespace CTFLibrary.Math.Test
{
    public class FactorTest
    {
        [Fact]
        public void MSieveTest()
        {
            Config.Init();
            var b = BigInteger.Parse("3141592653589793238");
            var factors = b.FactorWithMSieve();
            foreach (var item in factors)
            {
                Assert.True(IsPrime(item));
                Assert.Equal(0, b % item);
                b /= item;
            }
            Assert.Equal(1, b);
        }
        [Fact]
        public void FactorDBTest()
        {
            var b = BigInteger.Parse("3141592653589793238");
            var (factors, state) = b.FactorWithFactorDB();
            Assert.True(state);
            foreach (var item in factors)
            {
                Assert.True(IsPrime(item));
                Assert.Equal(0, b % item);
                b /= item;
            }
            Assert.Equal(1, b);
        }
        bool IsPrime(BigInteger b)
        {
            for (int i = 2; i * i <= b; i++) if (b % i == 0) return false;
            return true;
        }
    }
}
