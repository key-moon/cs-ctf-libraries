using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Numerics;
using System.Text;

namespace CTFLibrary
{
    public partial class RSA
    {
        public bool HasPrivateKey { get; private set; }
        private BigInteger _p;
        public BigInteger P => HasPrivateKey ? _p : throw new Exception();
        private BigInteger _q;
        public BigInteger Q => HasPrivateKey ? _q : throw new Exception();
        public BigInteger E { get; private set; }
        public BigInteger N { get; private set; }
        public BigInteger D => E.Inverse((P - 1) * (Q - 1));

        public void SetPrivateKey(BigInteger p, BigInteger q) { Trace.Assert(p * q == N); HasPrivateKey = true; _p = p; _q = q; }

        public RSA(BigInteger e, BigInteger p, BigInteger q)
        {
            E = e;
            N = p * q;
            SetPrivateKey(p, q);
        }
        public RSA(BigInteger e, BigInteger n)
        {
            E = e;
            N = n;
            HasPrivateKey = false;
        }

        public BigInteger Encrypt(BigInteger m) => BigInteger.ModPow(m, E, N);
        public BigInteger Decrypt(BigInteger c) => BigInteger.ModPow(c, D, N);
    }
}
