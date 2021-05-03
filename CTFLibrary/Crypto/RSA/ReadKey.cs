using System;
using System.Linq;
using System.IO;
using System.Collections.Generic;
using System.Numerics;
using System.Text;
using System.Text.RegularExpressions;
using System.Diagnostics;

namespace CTFLibrary
{
    public partial class RSA
    {
        public static RSA CreateFromKey(Stream stream) => CreateFromKey(new StreamReader(stream));
        public static RSA CreateFromKey(TextReader stream)
        {
            var s = stream.ReadToEnd();
            var tmp = Path.GetTempFileName();
            File.WriteAllText(tmp, s);
            return CreateFromKey(tmp);
        }
        public static RSA CreateFromKey(string path)
        {
            var (output, err) = ProcessUtil.ExecPython(@$"
from Crypto.PublicKey import RSA
key = RSA.importKey(open('{path.Replace("\\", "\\\\").Replace("'", "\\'")}').read())
print(f'e: {{key.e}}')
print(f'n: {{key.n}}')
if key.can_encrypt():
  print(f'p: {{key.p}}')
  print(f'q: {{key.q}}')
");
            if (err.Trim().Length != 0) throw new Exception(err);
            BigInteger p = 0;
            BigInteger q = 0;
            BigInteger n = 0;
            BigInteger e = 0;
            foreach (var line in output.Split('\n'))
            {
                if (Regex.IsMatch(line, @"^[enpq]: "))
                {
                    var val = line.Split(' ', 2).Last().Trim().ParseToBigInteger();
                    switch (line[0])
                    {
                        case 'e':
                            e = val;
                            break;
                        case 'n':
                            n = val;
                            break;
                        case 'p':
                            p = val;
                            break;
                        case 'q':
                            q = val;
                            break;
                    }
                }
            }
            if (e == 0) throw new Exception("key does not contains e");
            if (p != 0) return new RSA(e, p, q);
            if (n != 0) return new RSA(e, n);
            throw new Exception("invalid key");
        }
    }

    /*public partial class RSA
    {
        public static RSA CreateFromKey(string path) => CreateFromKey(new StreamReader(path));
        public static RSA CreateFromKey(Stream stream) => CreateFromKey(new StreamReader(stream));
        public static RSA CreateFromKey(TextReader stream)
        {
            var delimiter = stream.ReadLine();
            var parser = KeyFileParser.GetParserFromDelimiter(delimiter);
            StringBuilder builder = new StringBuilder();
            while (true)
            {
                var line = stream.ReadLine().Trim();
                if (line.Any(x => !Const.Base64Letters.Contains(x))) break;
                builder.Append(line);
            }
            var bytes = builder.ToString().DecodeFromBase64().ToByteArray();
            var reader = new BinaryReader(new MemoryStream(bytes));
            return parser.Parse(reader);
        }
    }*/
    interface KeyFileParser
    {
        public RSA Parse(BinaryReader reader);
        public static KeyFileParser GetParserFromDelimiter(string delimiter)
        {
            if (delimiter.Contains("BEGIN RSA PUBLIC KEY"))
                return new PKCS1Parser();
            if (delimiter.Contains("BEGIN PUBLIC KEY"))
                return new PKCS8Parser();
            throw new Exception("delimiter not found");
        }
    }
    class PKCS1Parser : KeyFileParser
    {
        public RSA Parse(BinaryReader reader)
        {
            ushort ReadUInt16() => (ushort)(reader.ReadByte() * 256 + reader.ReadByte());
            BigInteger ReadNumber()
            {
                Trace.Assert(reader.ReadByte() == 0x02);
                var _len = reader.ReadByte();
                var len = _len == 0x82 ? ReadUInt16() : _len;
                return new BigInteger(reader.ReadBytes(len), false, true);
            }
            // TODO: ASN1パーサを書く
            Trace.Assert(reader.ReadByte() == 0x30);
            Trace.Assert(reader.ReadByte() == 0x82);
            var totallen = ReadUInt16();
            var n = ReadNumber();
            var e = ReadNumber();
            return new RSA(e, n);
        }
    }
    // Only supports for PKCS#1
    class PKCS8Parser : KeyFileParser
    {
        public RSA Parse(BinaryReader reader)
        {
            ushort ReadUInt16() => (ushort)(reader.ReadByte() * 256 + reader.ReadByte());
            BigInteger ReadNumber()
            {
                Trace.Assert(reader.ReadByte() == 0x02);
                var _len = reader.ReadByte();
                var len = _len == 0x82 ? ReadUInt16() : _len;
                var data = reader.ReadBytes(len);
                return new BigInteger(data, false, true);
            }

            Trace.Assert(reader.ReadByte() == 0x30);
            Trace.Assert(reader.ReadByte() == 0x82);
            while (true)
            {
                while (reader.ReadByte() != 0x30) ;
                if (reader.ReadByte() == 0x82) break;
            }

            var totallen = ReadUInt16();
            var n = ReadNumber();
            var e = ReadNumber();
            return new RSA(e, n);
        }
    }
}
