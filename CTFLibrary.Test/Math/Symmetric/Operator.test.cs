using System;
using System.Linq;
using System.Collections.Generic;
using System.Numerics;
using Xunit;

using CTFLibrary;

namespace CTFLibrary.Math.Test
{
    public class SymmetricOperatorTest
    {
        [Fact]
        public void MulTest()
        {
            var perm = Symmetric.Create(new int[] { 1, 2, 3, 0 });
            Assert.Equal(new[] { 4, 1, 2, 3 }, new[] { 1, 2, 3, 4 } * perm);
            Assert.Equal(new[] { 3, 4, 1, 2 }, new[] { 1, 2, 3, 4 } * (perm * perm));
        }
        [Fact]
        public void DivTest()
        {
            var perm = Symmetric.Create(new int[] { 1, 2, 3, 0 });
            Assert.Equal(new[] { 2, 3, 4, 1 }, new[] { 1, 2, 3, 4 } / perm);
            Assert.Equal(new[] { 1, 2, 3, 4 }, new[] { 1, 2, 3, 4 } / (perm / perm));
        }
    }
}
