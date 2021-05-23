using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CTFLibrary
{
    public static partial class MyEncoding
    {
        public static Encoding Raw => new Raw();
    } 
    public class Raw : Encoding
    {
        public override int GetByteCount(char[] chars, int index, int count)
        {
            foreach (var c in chars.AsSpan()[index..(index + count)])
            {
                if ('\xff' < c) throw new Exception($"Invalid char {c}");
            }
            return count;
        }

        public override int GetBytes(char[] chars, int charIndex, int charCount, byte[] bytes, int byteIndex)
        {
            for (int i = 0; i < charCount; i++)
            {
                if ('\xff' < chars[i]) throw new Exception($"Invalid char {chars[i]}");
                bytes[i] = (byte)chars[i];
                charIndex++;
                byteIndex++;
            }
            return charCount;
        }

        public override int GetCharCount(byte[] bytes, int index, int count) => count;

        public override int GetChars(byte[] bytes, int byteIndex, int byteCount, char[] chars, int charIndex)
        {
            for (int i = 0; i < byteCount; i++)
            {
                chars[i] = (char)bytes[i];
                charIndex++;
                byteIndex++;
            }
            return byteCount;
        }

        public override int GetMaxByteCount(int charCount) => charCount;

        public override int GetMaxCharCount(int byteCount) => byteCount;
    }
}
