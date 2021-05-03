using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using MethodImplAttribute = System.Runtime.CompilerServices.MethodImplAttribute;
using MethodImplOptions = System.Runtime.CompilerServices.MethodImplOptions;

namespace CTFLibrary
{
    public static partial class MyMath
    {
        public static int BitLength(this BigInteger n)
        {
            var buf = n.ToByteArray(isUnsigned: true, isBigEndian: true);
            var res = buf.Length * 8;
            var s = (int)buf[0];
            s |= s >> 1;
            s |= s >> 2;
            s |= s >> 4;
            res -= s switch
            {
                255 => 0,
                127 => 1,
                63 => 2,
                31 => 3,
                15 => 4,
                7 => 5,
                3 => 6,
                1 => 7,
                _ => 8
            };
            return res;
        }
    }
}

