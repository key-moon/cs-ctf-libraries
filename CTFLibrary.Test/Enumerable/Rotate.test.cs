using System;
using System.Linq;
using System.Numerics;
using Xunit;

using CTFLibrary;

namespace CTFLibrary.Enumerable.Test
{
    public class RotateTest
    {
        [Fact]
        public void Test()
        {
            var left2 = new[] { 1, 2, 3, 4, 5, 6 }.RotateLeft(2).ToArray();
            var right2 = new[] { 1, 2, 3, 4, 5, 6 }.RotateRight(2).ToArray();
            Assert.Equal(left2, new[] { 3, 4, 5, 6, 1, 2 });
            Assert.Equal(right2, new[] { 5, 6, 1, 2, 3, 4 });
        }
    }
}
