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
            const int MAX = 1000000;
            var primes = Primes(MAX).ToHashSet();
            for (int i = 2; i <= MAX; i++)
            {
                Assert.Equal(primes.Contains(i), i.IsPrime());
                //Assert.Equal(primes.Contains(i), ((long)i).IsPrime());
                Assert.Equal(primes.Contains(i), ((BigInteger)i).IsPrime());
            }
        }
        public IEnumerable<int> Primes(int max)
        {
            bool[] table = new bool[max + 1];
            for (int i = 2; i <= max; i++)
            {
                if (table[i]) continue;
                yield return i;
                for (int j = i; j <= max; j += i) table[j] = true;
            }
        }
    }
}
