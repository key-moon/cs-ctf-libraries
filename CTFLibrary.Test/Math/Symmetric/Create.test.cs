using System;
using System.Linq;
using System.Collections.Generic;
using System.Numerics;
using Xunit;

using CTFLibrary;

namespace CTFLibrary.Math.Test
{
    public class SymmetricCreateTest
    {
        [Fact]
        public void Test()
        {
            var sym = Symmetric.Create(new int[] { 1, 2, 3, 0 });
            Assert.Equal(4, sym.Size);
            Assert.Equal(1, sym[0]);
            Assert.Equal(2, sym[1]);
            Assert.Equal(3, sym[2]);
            Assert.Equal(0, sym[3]);
            Assert.Throws<ArgumentException>(() => Symmetric.Create(new int[] { 1, 2, 3, 4 }));
        }
    }
}
