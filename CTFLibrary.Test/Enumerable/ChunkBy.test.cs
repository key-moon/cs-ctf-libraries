using System;
using System.Linq;
using System.Numerics;
using Xunit;

using CTFLibrary;

namespace CTFLibrary.Enumerable.Test
{
    public class ChunkByTest
    {
        [Fact]
        public void Test()
        {
            var chunked = new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 }.ChunkBy(4).ToArray();
            Assert.Equal(chunked[0], new[] { 1, 2, 3, 4 });
            Assert.Equal(chunked[1], new[] { 5, 6, 7, 8 });
            Assert.Equal(chunked[2], new[] { 9, 10 });
        }
    }
}
