using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CTFLibrary
{
    public static class Hex
    {
        public static Bytes FromHexString(this string s)
        {
            byte[] res = new byte[s.Length / 2];
            for (int i = 0; i < s.Length; i += 2)
                res[i >> 1] = Convert.ToByte(s.Substring(i, 2), 16);
            return res;
        }
        public static string ToHexString(this Bytes s)
        {
            StringBuilder builder = new StringBuilder(s.Length * 2);
            for (int i = 0; i < s.Length; i++)
                builder.Append(Convert.ToString(s[i], 16).PadLeft(2, '0'));
            return builder.ToString();
        }
        public static string Hexlify(this Bytes s) => s.ToHexString();
        public static Bytes UnHexlify(this string s) => s.FromHexString();
    }
}
