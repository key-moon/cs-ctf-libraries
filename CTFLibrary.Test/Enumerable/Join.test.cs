using System;
using System.Linq;
using System.Numerics;
using Xunit;

using CTFLibrary;

namespace CTFLibrary.Enumerable.Test
{
    public class JoinTest
    {
        [Fact]
        public void Test()
        {
            var join = new[] { 1, 2, 3, 4, 5, 6 }.Join();
            var joinchar = new[] { 1, 2, 3, 4, 5, 6 }.Join(' ');
            var joinstr = new[] { 1, 2, 3, 4, 5, 6 }.Join("__");
            Assert.Equal("123456", join);
            Assert.Equal("1 2 3 4 5 6", joinchar);
            Assert.Equal("1__2__3__4__5__6", joinstr);
        }
    }
}
