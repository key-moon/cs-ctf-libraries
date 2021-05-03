using System;
using System.Linq;
using System.Collections.Generic;
using System.Numerics;
using Xunit;

using CTFLibrary;

namespace CTFLibrary.Math.Test
{
    public class PrimesTest
    {
        [Fact]
        public void Test()
        {
            const int MAX = 10000;
            var primes = MyMath.Primes(MAX).ToArray();
            for (int i = 1; i < primes.Length; i++) Assert.True(primes[i - 1] < primes[i]);
            bool[] table = new bool[MAX + 1];
            table[0] = true;
            table[1] = true;
            foreach (var item in primes)
            {
                Assert.False(table[item]);
                for (int i = item; i <= MAX; i += item) table[i] = true;
            }
            Assert.True(table.All(x => x));
        }
    }
}
