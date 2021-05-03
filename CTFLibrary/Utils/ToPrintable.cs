using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace CTFLibrary
{
    public static partial class Utils
    {
        public static string ToPrintable(this string bytes, char replace = ' ')
        {
            return bytes.Select(x => Const.PrintableLetters.Contains(x) ? x : replace).Join();
        }
    }
}
