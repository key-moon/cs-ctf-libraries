using System;
using System.Linq;
using System.Numerics;
using Xunit;

using CTFLibrary;

namespace CTFLibrary.Crypto.Test
{
    public class SHATest
    {
        [Fact]
        public void SHA1Test()
        {
            var res = "test".ToBytes().GetSHA1();
            var ans = "a94a8fe5ccb19ba61c4c0873d391e987982fbbd3".UnHexlify();
            Assert.Equal(res, ans);
        }
        [Fact]
        public void SHA256Test()
        {
            var res = "test".ToBytes().GetSHA256();
            var ans = "9f86d081884c7d659a2feaa0c55ad015a3bf4f1b2b0b822cd15d6c15b0f00a08".UnHexlify();
            Assert.Equal(res, ans);
        }
        [Fact]
        public void SHA512Test()
        {
            var res = "test".ToBytes().GetSHA512();
            var ans = "ee26b0dd4af7e749aa1a8ee3c10ae9923f618980772e473f8819a5d4940e0db27ac185f8a0e1d5f84f88bc887fd67b143732c304cc5fa9ad8e6f57f50028a8ff".UnHexlify();
            Assert.Equal(res, ans);
        }
    }
}
