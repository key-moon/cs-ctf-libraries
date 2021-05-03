using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace CTFLibrary
{
    public static partial class Utils
    {
        public static (string res, string converters) AutoDecode(this Bytes bytes)
        {
            List<string> converter = new List<string>();
            while (true)
            {
                var bArray = bytes.ToByteArray();
                int[] a = new int[256];
                foreach (var c in bArray) a[c]++;

                bool isValid(string charset)
                {
                    int sum = 0;
                    foreach (var c in charset) sum += a[c];
                    return bArray.Length == sum;
                }

                
                if (BigInteger.TryParse(bytes.ToString(), out BigInteger res))
                {
                    bytes = res;
                    converter.Add("parseInt");
                    continue;
                }
                if (isValid(Const.HexLetters))
                {
                    bytes = bytes.ToString().UnHexlify();
                    converter.Add("UnHexlify");
                    continue;
                }

                if (isValid(Const.Base64Letters))
                {
                    bytes = bytes.ToString().DecodeFromBase64();
                    converter.Add("base64-d");
                    continue;
                }
                break;
            }
            return (bytes.ToString(), string.Join("->", converter));
        }
    }
}
