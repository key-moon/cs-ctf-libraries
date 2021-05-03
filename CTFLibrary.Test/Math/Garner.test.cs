using System;
using System.Numerics;
using Xunit;

using CTFLibrary;
using System.Linq;

namespace CTFLibrary.Math.Test
{
    public class GarnerTest
    {
        [Fact]
        public void Test()
        {
            BigInteger res = 5184235440977504549;
            BigInteger[] mods = new BigInteger[]
            {
                1061,
                197609,
                650179,
                916361
            };
            var vals = mods.Select(x => res % x).ToArray();
            Assert.Equal(MyMath.Garner(vals, mods), res);
        }
    }
}
