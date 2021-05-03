using System;
using System.Linq;
using System.Collections;
using System.Numerics;
using Xunit;

using CTFLibrary;

namespace CTFLibrary.Utils.Test
{
    public class ToPrintableTest
    {
        [Fact]
        public void Test()
        {
            string s = "";
            for (int i = 0; i < 256; i++) s += (char)i;
            s = s.ToPrintable();
            Assert.True(s.Except(Const.PrintableLetters).Count() == 0);
        }
    }
}
