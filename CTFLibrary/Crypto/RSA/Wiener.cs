using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace CTFLibrary
{
    public partial class RSA
    {
        public bool Wiener()
        {
            var rational = new Rational(e, n);
            List<BigInteger> A = new List<BigInteger>();
            int i = 0;
            foreach (var item in rational.ToContfrac())
            {
                var approxed = (Rational)item;
                if (i % 2 == 0) approxed += 1;
                foreach (var a in A.Reverse<BigInteger>())
                    approxed = a + 1 / approxed;
                var k = approxed.Numerator;
                var d = approxed.Denominator;
                //Console.WriteLine($"k={k}\nd={d}\nk/d={(double)approxed}");
                if (ValidateKD(k, d)) return true;

                A.Add(item);
                i++;
            }

            return false;
        }
        /// <summary>
        /// ed = k(p-1)(q-1) + 1 なる P,Qがあるか
        /// </summary>
        /// <param name="k"></param>
        /// <param name="d"></param>
        /// <returns></returns>
        bool ValidateKD(BigInteger k, BigInteger d)
        {
            if (k == 0 || d == 1 || (e * d - 1) % k != 0) return false;
            // \phi=(p-1)(q-1)=pq-p-q+1
            var phi = (e * d - 1) / k;
            // pq-(pq-p-q+1)+1=p+q
            var pPlusQ = n - phi + 1;
            // determine x^2-(p+q)x+pq=0 has integer answer
            var discremination = pPlusQ * pPlusQ - 4 * n;
            if (discremination < 0) return false;
            var sqrt = discremination.Sqrt();
            if (sqrt * sqrt != discremination) return false;
            if ((pPlusQ - sqrt) % 2 != 0) return false;
            HasPrivateKey = true;
            SetPrivateKey((pPlusQ + sqrt) / 2, (pPlusQ - sqrt) / 2);
            return true;
        }
    }
}
