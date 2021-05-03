using System;
using System.Linq;
using System.Numerics;
using Xunit;

using CTFLibrary;

namespace CTFLibrary.BytesTest
{
    public class ConvertTest
    {
        [Fact]
        public void ByteArrayConvertTest()
        {
            var arr = new byte[] { 0, 1, 2, 3 };
            Bytes b = Bytes.FromSpan(arr);
            Assert.Equal(new byte[] { 0, 1, 2, 3 }, b.ToByteArray());
            Assert.Equal(b, arr.ToBytes());
        }
        [Fact]
        public void StringConvertTest()
        {
            var arr = new byte[] { (byte)'a', (byte)'b', (byte)'c', (byte)'d' };
            Bytes b = Bytes.FromSpan(arr);
            Assert.Equal("abcd", b.ToString());
            Assert.Equal(b, "abcd".ToBytes());
        }
        [Fact]
        public void IntegerConvertTest()
        {
            var arr = new byte[] { 1, 2 };
            Bytes b = Bytes.FromSpan(arr);
            Assert.Equal(256 * 2 + 1, b.ToBigInteger());
            Assert.Equal(b, ((BigInteger)(256 * 2 + 1)).ToBytes());
        }
    }
}
