using System;
using System.IO;
using Xunit;

using CTFLibrary;

namespace CTFLibrary.Process.Test
{
    public class ProcTest
    {
        [Fact]
        public void StartTest()
        {
            using var ps = ProcessUtil.Start("powershell.exe", "");
            ps.StandardInput.WriteLine("echo test");
            ps.StandardInput.WriteLine("exit");
            var output = ps.StandardOutput.ReadToEnd();
            Assert.Contains("test", output);
        }
        [Fact]
        public void ExecTest()
        {
            var (output, err) = ProcessUtil.Exec("powershell.exe", "echo hello");
            Assert.Equal("hello", output.Trim());
            Assert.Equal("", err);
        }
    }
}
