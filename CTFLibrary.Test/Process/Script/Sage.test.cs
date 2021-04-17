using System;
using System.Numerics;
using Xunit;

using CTFLibrary;

namespace CTFLibrary.Process.Test
{
    public class SageTest
    {
        [Fact]
        public void StartSageTest()
        {
            using var ps = ProcessUtil.StartSage("R.<x> = QQ[]\nprint(eval(input(\"in:\\n\")))");
            var out1 = ps.StandardOutput.ReadLine();
            Assert.Equal("in:", out1.Trim());
            ps.StandardInput.WriteLine("(x+1) * (x+2)");
            var out2 = ps.StandardOutput.ReadLine();
            Assert.Equal("x^2 + 3*x + 2", out2.Trim());
        }
        [Fact]
        public void ExecSageTest()
        {
            var (output, err) = ProcessUtil.ExecSage(@"print(EllipticCurve(""5077a"").rank())");
            Assert.Equal("3", output.Trim());
            Assert.Equal("", err);
        }
    }
}
