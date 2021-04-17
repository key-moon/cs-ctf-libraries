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
        public Symmetric Pow(BigInteger i)
        {
            if (i < 0) return Inverse().Pow(-i);
            var pow = this;
            var res = Identity(Size);
            while (i > 0)
            {
                if ((i & 1) == 1) res *= pow;
                pow *= pow;
                i >>= 1;
            }
            return res;
        }
    }
}

