using System;
using System.Numerics;
using System.Collections.Generic;
using System.Text;

namespace CTFLibrary
{
    public partial class RSA
    {
        public delegate bool DigitPredicate(BigInteger p, BigInteger q, LowerBit bit);
        /// <summary>
        /// 下位 bit より p, q を確定させていく分枝限定法を用いた素因数分解<br></br>
        /// p xor q が分かっている場合や p と q の bit がランダムに露出している場合等に有効
        /// </summary>
        /// <param name="factorMethod"></param>
        /// <returns></returns>
        public bool BranchAndBound(DigitPredicate predicate)
        {
            Stack<(BigInteger p, BigInteger q, int dig)> stack = new Stack<(BigInteger p, BigInteger q, int dig)>();
            stack.Push((0, 0, 0));
            var nBitLen= N.BitLength();
            while (stack.Count != 0)
            {
                var (p, q, bit) = stack.Pop();
                if (nBitLen <= bit) continue;
                var nxt = BigInteger.One << bit;
                var lowerBit = new LowerBit() { Count = bit, Mask = nxt * 2 - 1 };
                for (int i = 0; i <= 1; i++)
                {
                    for (int j = 0; j <= 1; j++)
                    {
                        var np = i == 0 ? p : p + nxt;
                        var nq = j == 0 ? q : q + nxt;
                        if (!predicate(np, nq, lowerBit)) continue;
                        var nn = np * nq;
                        if ((nn & lowerBit.Mask) != (N & lowerBit.Mask) || N < nn) continue;
                        if (nn == N) { SetPrivateKey(np, nq); return true; }
                        stack.Push((np, nq, bit + 1));
                    }
                }
            }
            return false;
        }
    }
    public class LowerBit
    {
        public int Count { get; init; }
        public BigInteger Mask { get; init; }
    }
}
