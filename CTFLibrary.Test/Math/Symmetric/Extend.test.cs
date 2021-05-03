using System;
using System.Linq;
using System.Collections.Generic;
using System.Numerics;
using Xunit;

using CTFLibrary;

namespace CTFLibrary.Math.Test
{
    public class SymmetricExtendTest
    {
        [Fact]
        public void Test()
        {
            var perm = Symmetric.Create(new int[] { 1, 2, 3, 0 }).Extend(6);
            Assert.Equal(6, perm.Size);
            Assert.Equal(1, perm[0]);
            Assert.Equal(2, perm[1]);
            Assert.Equal(3, perm[2]);
            Assert.Equal(0, perm[3]);
            Assert.Equal(4, perm[4]);
            Assert.Equal(5, perm[5]);
        }
    }
}
