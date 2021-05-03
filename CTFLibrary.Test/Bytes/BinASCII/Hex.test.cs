using System;
using System.Linq;
using System.Numerics;
using Xunit;

using CTFLibrary;

namespace CTFLibrary.BytesTest
{
    public class HexTest
    {
        [Fact]
        public void ToHexStringTest()
        {
            var b = Bytes.FromSpan(new byte[] { (byte)'a', (byte)'b', (byte)'c' });
            Assert.Equal("616263", b.Hexlify());
            Assert.Equal("616263", b.ToHexString());
        }
        [Fact]
        public void FromHexStringTest()
        {
            var b = Bytes.FromSpan(new byte[] { (byte)'a', (byte)'b', (byte)'c' });
            Assert.Equal(b, "616263".FromHexString());
            Assert.Equal(b, "616263".UnHexlify());
        }
    }
}
