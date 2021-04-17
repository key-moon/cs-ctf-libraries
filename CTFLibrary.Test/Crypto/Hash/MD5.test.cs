using System;
using System.Linq;
using System.Numerics;
using Xunit;

using CTFLibrary;

namespace CTFLibrary.Crypto.Test
{
    public class MD5Test
    {
        [Fact]
        public void Test()
        {
            var res = "test".ToBytes().GetMD5();
            var ans = "098f6bcd4621d373cade4e832627b4f6".UnHexlify();
            Assert.Equal(res, ans);
        }
    }
}
