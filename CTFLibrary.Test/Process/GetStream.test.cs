using System;
using System.IO;
using Xunit;

using CTFLibrary;

namespace CTFLibrary.Process.Test
{
    public class GetStreamTest
    {
        [Fact]
        public void Test()
        {
            using var ps = ProcessUtil.Start("cmd.exe", "");
            using var stream = ps.GetStream();
            using var reader = new StreamReader(stream);
            using var writer = new StreamWriter(stream) { AutoFlush = true };
            writer.WriteLine("set /a 123*456");
            writer.WriteLine("exit");
            var res = reader.ReadToEnd();
            Assert.Contains((123 * 456).ToString(), res);
        }
    }
}
