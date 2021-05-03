using System;
using System.Linq;
using System.Numerics;
using Xunit;

using CTFLibrary;

namespace CTFLibrary.Crypto.Test
{
    public class RSANaiveTest
    {
        [Fact]
        public void Test()
        {
            Config.Init();
            int n = 64741;
            var rsa = new RSA(3, n);
            var res = rsa.Naive(MyMath.FactorMethod.MSieve);
            Assert.True(res);
            Assert.True(n == rsa.P * rsa.Q);
        }
    }
}
