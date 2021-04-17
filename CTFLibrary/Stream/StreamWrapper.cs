using System;
using System.Linq;
using System.IO;
using System.Collections.Generic;
using System.Text;

namespace CTFLibrary
{
    public class StreamWrapper : IDisposable
    {
        public static bool DefaultAutoFlush = true;

        private Stream _BaseStream;
        public Stream BaseStream
        {
            get => _BaseStream;
            set
            {
                Reader = new StreamReader(value);
                Writer = new StreamWriter(value) { AutoFlush = DefaultAutoFlush };
                _BaseStream = value;
            }
        }
        public Encoding Encoding => Reader.CurrentEncoding == Writer.Encoding ? Writer.Encoding : throw new Exception();

        public StreamReader Reader { get; private set; }
        public bool EndOfStream => Reader.EndOfStream;

        public StreamWriter Writer { get; private set; }
        public bool AutoFlush { get => Writer.AutoFlush; set => Writer.AutoFlush = value; }
        public string NewLine { get => Writer.NewLine; set => Writer.NewLine = value; }
        public IFormatProvider FormatProvider => Writer.FormatProvider;
        
        public StreamWrapper(Stream stream) { BaseStream = stream; }

        public char Read() => (char)Reader.Read();
        public string Read(int n)
        {
            char[] buf = new char[n];
            Reader.Read(buf.AsSpan());
            return string.Join("", buf);
        }
        public string ReadBlock(int n)
        {
            char[] buf = new char[n];
            Reader.ReadBlock(buf.AsSpan());
            return string.Join("", buf);
        }
        public string ReadLine() => Reader.ReadLine();
        public string ReadUntil(string s)
        {
            var n = s.Length;
            List<char> data = Read(n).ToList();
            while (!data.TakeLast(n).SequenceEqual(s)) data.Add(Read());
            return string.Join("", data);
        }
        public string ReadToEnd() => Reader.ReadToEnd();
        public char Peek() => (char)Reader.Peek();

        public void Write(object o) => Writer.Write(o);
        public void Write(string o) => Writer.Write(o);
        public void WriteLine(object o) => Writer.WriteLine(o);
        public void WriteLine(string o) => Writer.WriteLine(o);
        public void Flush() => Writer.Flush();
        public void Dispose()
        {
            BaseStream.Dispose();
            Reader.Dispose();
            Writer.Dispose();
        }
    }
}
