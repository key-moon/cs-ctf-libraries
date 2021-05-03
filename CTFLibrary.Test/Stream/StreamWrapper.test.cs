using System;
using System.IO;
using Xunit;

using CTFLibrary;

namespace CTFLibrary.Stream.Test
{
    public class StreamWrapperTest
    {
        [Fact]
        public void Test()
        {
            byte[] inbuf = "iin1\nin2in3\nin4in5".ToByteArray();
            var inStream = new MemoryStream(inbuf);
            var outStream = new MemoryStream();
            var outReader = new StreamReader(outStream);
            var wrapeer = new StreamWrapper(new MergedStream(inStream, outStream));

            Assert.Equal('i', wrapeer.Read());
            Assert.Equal("in1", wrapeer.ReadLine());
            Assert.Equal("in2", wrapeer.ReadUntil("in2"));
            Assert.Equal("in3", wrapeer.ReadLine());

            wrapeer.Write('o');
            wrapeer.WriteLine("out1");
            wrapeer.WriteAfter("in4", "out2");
            wrapeer.WriteLineAfter("in5", "out3");
            outStream.Position = 0;
            Assert.Equal("oout1\nout2out3\n", outReader.ReadToEnd());
        }
    }
}
