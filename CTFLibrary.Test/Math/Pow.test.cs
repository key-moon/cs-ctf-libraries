﻿using System;
using System.Numerics;
using Xunit;

using CTFLibrary;

namespace CTFLibrary.Test
{
    public class PowTest
    {
        [Fact]
        public void Test()
        {
            BigInteger n = 2;
            int exp = 127;
            var expect = BigInteger.Pow(n, exp);
            Assert.Equal(expect, n.Pow((int)exp));
            Assert.Equal(expect, n.Pow((long)exp));
            Assert.Equal(expect, n.Pow((BigInteger)exp));
        }
    }
}
