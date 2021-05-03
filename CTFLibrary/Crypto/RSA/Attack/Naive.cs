using System;
using System.Numerics;
using System.Collections.Generic;
using System.Text;

namespace CTFLibrary
{
    public partial class RSA
    {
        /// <summary>
        /// ナイーブな素因数分解
        /// </summary>
        /// <param name="factorMethod"></param>
        /// <returns></returns>
        public bool Naive(MyMath.FactorMethod factorMethod = MyMath.FactorMethod.Default)
        {
            BigInteger[] factors;
            try
            {
                factors = N.Factor(factorMethod);
            }
            catch
            {
                return false;
            }
            if (factors.Length != 2) return false;
            SetPrivateKey(factors[0], factors[1]);
            return true;
        }
    }
}
