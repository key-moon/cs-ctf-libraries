using System;
using System.Linq;
using System.Collections.Generic;
using System.Numerics;
using Xunit;

using CTFLibrary;

namespace CTFLibrary.Math.Test
{
    public class SymmetricSpecialTest
    {
        [Fact]
        public void ReverseTest()
        {
            var rev = Symmetric.Reverse(5);
            Assert.Equal(5, rev.Size);
            Assert.Equal(4, rev[0]);
            Assert.Equal(3, rev[1]);
            Assert.Equal(2, rev[2]);
            Assert.Equal(1, rev[3]);
            Assert.Equal(0, rev[4]);
        }
        [Fact]
        public void IdentityTest()
        {
            var id = Symmetric.Identity(5);
            Assert.Equal(5, id.Size);
            Assert.Equal(0, id[0]);
            Assert.Equal(1, id[1]);
            Assert.Equal(2, id[2]);
            Assert.Equal(3, id[3]);
            Assert.Equal(4, id[4]);
        }
        [Fact]
        public void RotateLeftTest()
        {
            var rot = Symmetric.RotateLeft(5, 2);
            Assert.Equal(5, rot.Size);
            Assert.Equal(3, rot[0]);
            Assert.Equal(4, rot[1]);
            Assert.Equal(0, rot[2]);
            Assert.Equal(1, rot[3]);
            Assert.Equal(2, rot[4]);
        }
        [Fact]
        public void RotateRightTest()
        {
            var rot = Symmetric.RotateRight(5, 2);
            Assert.Equal(5, rot.Size);
            Assert.Equal(2, rot[0]);
            Assert.Equal(3, rot[1]);
            Assert.Equal(4, rot[2]);
            Assert.Equal(0, rot[3]);
            Assert.Equal(1, rot[4]);
        }
    }
}
