using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace CTFLibrary
{
    public static partial class MyMath
    {
        public static ModInt<ModT> Pow<ModT>(this ModInt<ModT> n, int i) where ModT : IMod
        {
            ModInt<ModT> pow = n;
            ModInt<ModT> res = new ModInt<ModT>(1);
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
