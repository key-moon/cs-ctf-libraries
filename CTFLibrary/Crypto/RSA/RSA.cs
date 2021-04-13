using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace CTFLibrary
{
    public partial class RSA
    {
        public bool HasPrivateKey { get; private set; }
        private BigInteger _p;
        public BigInteger p
        {
            get => HasPrivateKey ? _p : throw new Exception();
        }
        private BigInteger _q;
        public BigInteger q
        {
            get => HasPrivateKey ? _q : throw new Exception();
        }
        public BigInteger e { get; private set; }
        public BigInteger n { get; private set; }
        public BigInteger d => e.Inverse((p - 1) * (q - 1));

        public void SetPrivateKey(BigInteger p, BigInteger q) { HasPrivateKey = true; _p = p; _q = q; }

        public RSA(BigInteger p, BigInteger q, BigInteger e)
        {
            HasPrivateKey = true;
            SetPrivateKey(p, q);
            this.e = e;
            this.n = p * q;
        }
        public RSA(BigInteger e, BigInteger n)
        {
            HasPrivateKey = false;
            this.e = e;
            this.n = n;
        }

        public BigInteger Encrypt(BigInteger m) => BigInteger.ModPow(m, e, n);
        public BigInteger Decrypt(BigInteger c) => BigInteger.ModPow(c, d, n);
    }
}
