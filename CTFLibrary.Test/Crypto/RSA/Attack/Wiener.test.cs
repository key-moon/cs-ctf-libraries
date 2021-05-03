using System;
using System.Linq;
using System.Numerics;
using Xunit;

using CTFLibrary;

namespace CTFLibrary.Crypto.Test
{
    public class RSAWienerTest
    {
        [Fact]
        public void Test()
        {
            var rsa = new RSA(42667, 64741);
            Assert.True(rsa.Wiener());
            Assert.Equal(64741, rsa.P * rsa.Q);
        }
    }
}
