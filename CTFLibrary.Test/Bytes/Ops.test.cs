using System;
using System.Linq;
using System.Numerics;
using Xunit;

using CTFLibrary;

namespace CTFLibrary.BytesTest
{
    public class OpsTest
    {
        [Fact]
        public void AddTest()
        {
            Bytes a = Bytes.FromSpan(new byte[] { 1, 131 });
            Bytes b = Bytes.FromSpan(new byte[] { 3, 132 });
            var c = a + b;
            Assert.Equal(4, c.Length);
            Assert.Equal(1, c[0]);
            Assert.Equal(131, c[1]);
            Assert.Equal(3, c[2]);
            Assert.Equal(132, c[3]);
        }
        [Fact]
        public void MulTest()
        {
            Bytes a = Bytes.FromSpan(new byte[] { 1, 131 });
            var c = a * 2;
            Assert.Equal(4, c.Length);
            Assert.Equal(1, c[0]);
            Assert.Equal(131, c[1]);
            Assert.Equal(1, c[2]);
            Assert.Equal(131, c[3]);
        }
        [Fact]
        public void XorTest()
        {
            Bytes a = Bytes.FromSpan(new byte[] { 1, 10 });
            Bytes b = Bytes.FromSpan(new byte[] { 10, 100 });
            var c = a ^ b;
            Assert.Equal(2, c.Length);
            Assert.Equal(1 ^ 10, c[0]);
            Assert.Equal(10 ^ 100, c[1]);
        }
        [Fact]
        public void AndTest()
        {
            Bytes a = Bytes.FromSpan(new byte[] { 10, 20 });
            Bytes b = Bytes.FromSpan(new byte[] { 30, 40 });
            var c = a & b;
            Assert.Equal(2, c.Length);
            Assert.Equal(10 & 30, c[0]);
            Assert.Equal(20 & 40, c[1]);
        }
        [Fact]
        public void OrTest()
        {
            Bytes a = Bytes.FromSpan(new byte[] { 10, 20 });
            Bytes b = Bytes.FromSpan(new byte[] { 30, 40 });
            var c = a | b;
            Assert.Equal(2, c.Length);
            Assert.Equal(10 | 30, c[0]);
            Assert.Equal(20 | 40, c[1]);
        }
        [Fact]
        public void EqTest()
        {
            Bytes a = Bytes.FromSpan(new byte[] { 10, 20 });
            Bytes b = Bytes.FromSpan(new byte[] { 10, 20 });
            Assert.True(a == b);
        }
        [Fact]
        public void NeqTest()
        {
            Bytes a = Bytes.FromSpan(new byte[] { 10, 20 });
            Bytes b = Bytes.FromSpan(new byte[] { 10, 20, 30 });
            Assert.True(a != b);
        }
        // Casts tests located in Convert.test.cs
    }
}
