using System;
using System.Numerics;
using Xunit;

using CTFLibrary;

namespace CTFLibrary.Utils.Test
{
    public class RadixTest
    {
        [Fact]
        public void ParseToBigIntegerTest()
        {
            Assert.Equal(BigInteger.Parse("12345"), "12345".ParseToBigInteger());
        }
        [Fact]
        public void ParseFromBaseKTest()
        {
            Assert.Equal(10 * 11 + 10, "aa".ParseFromBaseK(11));
        }
        [Fact]
        public void ToBaseKStringTest()
        {
            Assert.Equal("aa", ((BigInteger)(10 * 11 + 10)).ToBaseKString(11));
        }
        [Fact]
        public void DecodeFromBase64Test()
        {
            Assert.Equal("test".ToBytes(), "dGVzdA==".DecodeFromBase64());
        }
        [Fact]
        public void EncodeToBase64Test()
        {
            Assert.Equal("dGVzdA==", "test".ToBytes().EncodeToBase64());
        }
    }
}
