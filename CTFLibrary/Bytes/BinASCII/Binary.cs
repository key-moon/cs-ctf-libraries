using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CTFLibrary
{
    public static class Binary
    {
        public static Bytes FromBinaryString(this string s)
        {
            s = s.PadLeft((s.Length + 7) / 8 * 8, '0');
            byte[] res = new byte[s.Length / 8];
            for (int i = 0; i < s.Length; i += 8)
                res[i / 8] = Convert.ToByte(s.Substring(i, 8), 2);
            return res;
        }
        public static string ToBinaryString(this Bytes s)
        {
            StringBuilder builder = new StringBuilder(s.Length * 8);
            for (int i = 0; i < s.Length; i++)
                builder.Append(Convert.ToString(s[i], 2).PadLeft(8, '0'));
            return builder.ToString();
        }
    }
}
