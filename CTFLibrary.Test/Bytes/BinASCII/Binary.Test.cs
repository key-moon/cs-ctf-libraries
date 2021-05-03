using System;
using System.Linq;
using System.Numerics;
using Xunit;

using CTFLibrary;

namespace CTFLibrary.BytesTest
{
    public class BinaryTest
    {
        [Fact]
        public void ToBinaryStringTest()
        {
            var b = Bytes.FromSpan(new byte[] { (byte)'a', (byte)'b', (byte)'c' });
            Assert.Equal("011000010110001001100011", b.ToBinaryString());
        }
        [Fact]
        public void FromBinaryStringTest()
        {
            var b = Bytes.FromSpan(new byte[] { (byte)'a', (byte)'b', (byte)'c' });
            Assert.Equal(b, "011000010110001001100011".FromBinaryString());
        }
    }
}
