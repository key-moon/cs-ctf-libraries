using System;
using System.Linq;
using System.IO;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CTFLibrary
{
    public partial class StreamWrapper : IDisposable
    {
        public static bool DefaultAutoFlush { get; set; } = true;
        public static string DefaultNewLine { get; set; } = "\n";
        public static Encoding DefaultEncoding { get; set; } = Encoding.Default;

        private Stream _BaseStream;
        public Stream BaseStream
        {
            get => _BaseStream;
            private set
            {
                Reader = new StreamReader(value, DefaultEncoding);
                Writer = new StreamWriter(value, DefaultEncoding) { AutoFlush = DefaultAutoFlush, NewLine = DefaultNewLine };
                _BaseStream = value;
            }
        }
        public Encoding Encoding { get; }

        public StreamReader Reader { get; private set; }
        public bool EndOfStream => Reader.EndOfStream;

        public StreamWriter Writer { get; private set; }
        public bool AutoFlush { get => Writer.AutoFlush; set => Writer.AutoFlush = value; }
        public string NewLine { get => Writer.NewLine; set => Writer.NewLine = value; }
        public IFormatProvider FormatProvider => Writer.FormatProvider;

        public StreamWrapper(Stream stream) : this(stream, DefaultEncoding) { }
        public StreamWrapper(Stream stream, Encoding encoding) { Encoding = encoding; BaseStream = stream; }

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
        public string ReadLineAfter(string s) { ReadUntil(s); return Reader.ReadLine(); }
        public string ReadToEnd() => Reader.ReadToEnd();
        public char Peek() => (char)Reader.Peek();

        public void Write(object obj) => Writer.Write(obj);
        public void Write(Bytes bytes) => Writer.BaseStream.Write(bytes, 0, bytes.Length);
        public void Write(string s) => Writer.Write(s);
        public string WriteAfter(string nxt, object obj) { var res = ReadUntil(nxt); Write(obj); return res; }
        public string WriteAfter(string nxt, Bytes bytes) { var res = ReadUntil(nxt); Write(bytes); return res; }
        public string WriteAfter(string nxt, string s) { var res = ReadUntil(nxt); Write(s); return res; }
        public void WriteLine(object obj) => Writer.WriteLine(obj);
        public void WriteLine(Bytes bytes) { Write(bytes); WriteLine(""); }
        public void WriteLine(string s) => Writer.WriteLine(s);
        public string WriteLineAfter(string nxt, object obj) { var res = ReadUntil(nxt); WriteLine(obj); return res; }
        public string WriteLineAfter(string nxt, Bytes bytes) { var res = ReadUntil(nxt); WriteLine(bytes); return res; }
        public string WriteLineAfter(string nxt, string s) { var res = ReadUntil(nxt); WriteLine(s); return res; }
        public void Flush() => Writer.Flush();
        
        public void Interactive()
        {
            Task.Run(() => { char c; while (true) if ((c = Read()) != '\xff') Console.Write(c); });
            while (true) Writer.WriteLine(Console.ReadLine());
        }

        public void Dispose()
        {
            BaseStream.Dispose();
            Reader.Dispose();
            Writer.Dispose();
        }
    }
}
