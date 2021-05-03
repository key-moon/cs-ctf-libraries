using System;
using System.Linq;
using System.Numerics;
using Xunit;

using CTFLibrary;

namespace CTFLibrary.BytesTest
{
    public class BytesTest
    {
        [Fact]
        public void IndexerTest()
        {
            Bytes b = Bytes.FromSpan(new byte[] { 0, 1, 2 });
            Assert.Equal(0, b[0]);
            Assert.Equal(1, b[1]);
            Assert.Equal(2, b[2]);
        }
        [Fact]
        public void GetBitTest()
        {
            Bytes b = Bytes.FromSpan(new byte[] { 0b00110101, 0b11001010 });
            Assert.Equal(1, b.GetBit(0));
            Assert.Equal(0, b.GetBit(1));
            Assert.Equal(1, b.GetBit(2));
            Assert.Equal(0, b.GetBit(3));
            Assert.Equal(1, b.GetBit(4));
            Assert.Equal(1, b.GetBit(5));
            Assert.Equal(0, b.GetBit(6));
            Assert.Equal(0, b.GetBit(7));

            Assert.Equal(0, b.GetBit(8));
            Assert.Equal(1, b.GetBit(9));
            Assert.Equal(0, b.GetBit(10));
            Assert.Equal(1, b.GetBit(11));
            Assert.Equal(0, b.GetBit(12));
            Assert.Equal(0, b.GetBit(13));
            Assert.Equal(1, b.GetBit(14));
            Assert.Equal(1, b.GetBit(15));
        }
        [Fact]
        public void SliceTest()
        {
            Bytes b = Bytes.FromSpan(new byte[] { 0, 1, 2, 3, 4, 5 }).Slice(1, 3);
            Assert.Equal(3, b.Length);
            Assert.Equal(1, b[0]);
            Assert.Equal(2, b[1]);
            Assert.Equal(3, b[2]);
        }
    }
}
