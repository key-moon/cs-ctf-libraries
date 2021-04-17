using System;
using System.Linq;
using System.Collections.Generic;
using System.Numerics;
using Xunit;

using CTFLibrary;

namespace CTFLibrary.Math.Test
{
    public class IsPrimeTest
    {
        [Fact]
        public void Test()
        {
            const int MAX = 10000;
            var primes = MyMath.Primes(10000).ToHashSet();
            for (int i = 2; i <= MAX; i++)
            {
                Assert.Equal(primes.Contains(i), i.IsPrime());
                Assert.Equal(primes.Contains(i), ((long)i).IsPrime());
                Assert.Equal(primes.Contains(i), ((BigInteger)i).IsPrime());
            }
        }
    }
}
