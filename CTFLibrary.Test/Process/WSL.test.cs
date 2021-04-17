using System;
using System.IO;
using Xunit;

using CTFLibrary;

namespace CTFLibrary.Process.Test
{
    public class WSLTest
    {
        [Fact]
        public void StartOnWSLTest()
        {
            using var ps = ProcessUtil.StartOnWSL("read A B ; echo $((A*B))");
            ps.StandardInput.Write("123 456\n");
            var out1 = ps.StandardOutput.ReadLine();
            var err = ps.StandardError.ReadToEnd();
            Assert.Contains("56088", out1 + err);
        }
        [Fact]
        public void ExecOnWSLTest()
        {
            var (output, err) = ProcessUtil.ExecOnWSL("factor", "31415 9265");
            Assert.Contains("31415: 5 61 103", output);
            Assert.Contains("9265: 5 17 109", output);
            Assert.Equal("", err);
        }
    }
}
