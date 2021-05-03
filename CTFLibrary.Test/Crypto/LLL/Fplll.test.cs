using System;
using System.Linq;
using System.Numerics;
using Xunit;

namespace CTFLibrary.Crypto.Test
{
    public class FplllTest
    {
        BigInteger[][] Data =
        {
            new BigInteger[]{ 829556, 1, 0, 0, 0, 0, },
            new BigInteger[]{ 161099, 0, 1, 0, 0, 0, },
            new BigInteger[]{  11567, 0, 0, 1, 0, 0, },
            new BigInteger[]{ 521155, 0, 0, 0, 1, 0, },
            new BigInteger[]{ 769480, 0, 0, 0, 0, 1, }
        };
        [Fact]
        public void Test()
        {
            Config.Init();
            var lllRes = Data.LLLWithFplll();
            Assert.Equal(5, lllRes.Length);
            foreach (var row in lllRes) Assert.Equal(6, row.Length);
            var bkzRes = Data.BKZWithFplll();
            Assert.Equal(5, bkzRes.Length);
            foreach (var row in bkzRes) Assert.Equal(6, row.Length);

            var svpRes = Data.SVPWithFplll();
            Assert.Equal(6, svpRes.Length);
            var cvpRes = Data.CVPWithFplll(new BigInteger[] { 314, 159, 653, 589, 793, 238 });
            Assert.Equal(6, cvpRes.Length);
        }
    }
}
