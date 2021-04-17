using System;
using System.Linq;
using System.Numerics;
using Xunit;

using CTFLibrary;

namespace CTFLibrary.Crypto.Test
{
    public class RSATest
    {
        [Fact]
        public void Test()
        {
            var rsa = new RSA(11, 7, 37);
            var m = (BigInteger)15;
            var c = rsa.Encrypt(m);
            var m2 = rsa.Decrypt(c);
            Assert.Equal(m, m2);
        }
    }
}
