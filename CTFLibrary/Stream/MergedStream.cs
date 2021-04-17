using System;
using System.IO;

namespace CTFLibrary
{
    public class MergedStream : Stream
    {
        public Stream InStream { get; private set; }
        public Stream OutStream { get; private set; }
        public MergedStream(Stream inStream, Stream outStream) { InStream = inStream; OutStream = outStream; }

        public override bool CanRead => InStream.CanRead;

        public override bool CanSeek => false;

        public override bool CanWrite => OutStream.CanWrite;

        public override long Length => throw new NotImplementedException();

        public override long Position { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public override void Flush() => OutStream.Flush();

        public override int Read(byte[] buffer, int offset, int count) => InStream.Read(buffer, offset, count);

        public override long Seek(long offset, SeekOrigin origin)
        {
            throw new NotImplementedException();
        }

        public override void SetLength(long value)
        {
            throw new NotImplementedException();
        }

        public override void Write(byte[] buffer, int offset, int count) => OutStream.Write(buffer, offset, count);
    }
}
