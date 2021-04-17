using System;
using System.IO;
using System.Linq;
using Xunit;

using CTFLibrary;

namespace CTFLibrary.Stream.Test
{
    public class MergedStreamTest
    {
        [Fact]
        public void Test()
        {
            byte[] inbuf = { (byte)'i', (byte)'n', (byte)'\n' };
            var inStream = new MemoryStream(inbuf);
            var outStream = new MemoryStream();
            var mergedStream = new MergedStream(inStream, outStream);
            byte[] outbuf = { (byte)'o', (byte)'u', (byte)'t', (byte)'\n' };
            mergedStream.Write(outbuf);
            Assert.Equal("in", new StreamReader(mergedStream).ReadLine().Trim());
            outStream.Position = 0;
            Assert.Equal("out", new StreamReader(outStream).ReadLine().Trim());
        }
    }
}
