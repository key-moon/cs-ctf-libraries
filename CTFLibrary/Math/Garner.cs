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
    public static partial class MyMath
    {
        public static BigInteger Garner(BigInteger[] val, BigInteger[] mod)
        {
            if (val.Length != mod.Length) throw new Exception();
            int n = val.Length;
            BigInteger[] gamma = new BigInteger[n];
            for (int i = 0; i < n; i++)
            {
                BigInteger tmp = 1;
                for (int j = 0; j < i; j++) tmp = tmp * mod[j] % mod[i];
                gamma[i] = tmp.Inverse(mod[i]);
            }

            BigInteger[] v = new BigInteger[n];
            v[0] = val[0];
            for (int i = 1; i < n; i++)
            {
                BigInteger tmp = v[i - 1];
                for (int j = i - 2; j >= 0; j--) tmp = (tmp * mod[j] + v[j]) % mod[i];
                v[i] = (val[i] - tmp) * gamma[i] % mod[i];
                if (v[i] < 0) v[i] += mod[i];
            }
            BigInteger res = 0;
            for (int i = v.Length - 1; i >= 0; i--) res = res * mod[i] + v[i];
            return res;
        }
    }
}

