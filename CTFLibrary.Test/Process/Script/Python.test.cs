using System;
using System.Numerics;
using Xunit;

using CTFLibrary;

namespace CTFLibrary.Process.Test
{
    public class PythonTest
    {
        [Fact]
        public void StartPythonTest()
        {
            using var ps = ProcessUtil.StartPython(@"print(input(""in:\n""))");
            var out1 = ps.StandardOutput.ReadLine();
            Assert.Equal("in:", out1.Trim());
            ps.StandardInput.WriteLine("test");
            var out2 = ps.StandardOutput.ReadLine();
            Assert.Equal("test", out2.Trim());
        }
        [Fact]
        public void ExecPythonTest()
        {
            var (output, err) = ProcessUtil.ExecPython(@"print(1 + 1)");
            Assert.Equal("2", output.Trim());
            Assert.Equal("", err);
        }
    }
}
