using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CTFLibrary
{
    public partial class Symmetric
    {
        public Symmetric Extend(int len)
        {
            if (len < Size) throw new ArgumentException("should be larger than size", nameof(len));
            var res = new int[len];
            Permute.CopyTo(res, 0);
            for (int i = Size; i < len; i++) res[i] = i;
            return new Symmetric(res);
        }
    }
}

