using System;
using System.Linq;
using System.Numerics;
using Xunit;

using CTFLibrary;

namespace CTFLibrary.Crypto.Test
{
    public class RSABranchAndBoundTest
    {
        [Fact]
        public void Test()
        {
            BigInteger p = 5323910339802728171;
            BigInteger q = 4777244790709507121;
            var xor = p ^ q;
            var rsa = new RSA(65537, p * q);
            var res = rsa.BranchAndBound((p, q, bit) => (p ^ q) == (xor & bit.Mask));
            Assert.True(res);
            Assert.True(rsa.P * rsa.Q == p * q);
        }
    }
}
