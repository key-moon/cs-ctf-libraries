using System;
using System.Linq;
using System.Collections.Generic;
using System.Numerics;
using Xunit;

using CTFLibrary;

namespace CTFLibrary.Math.Test
{
    public class SymmetricInverseTest
    {
        [Fact]
        public void Test()
        {
            var sym = Symmetric.Create(new int[] { 1, 2, 3, 0 }).Inverse();
            Assert.Equal(4, sym.Size);
            Assert.Equal(3, sym[0]);
            Assert.Equal(0, sym[1]);
            Assert.Equal(1, sym[2]);
            Assert.Equal(2, sym[3]);
        }
    }
}
