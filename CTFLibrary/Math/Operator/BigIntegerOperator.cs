using System;
using System.Numerics;

namespace CTFLibrary
{
    public struct BigIntegerOperator : IOperator<BigInteger>
    {
        public BigInteger Neg(BigInteger val) => -val;
        public BigInteger Incr(BigInteger val) => val++;
        public BigInteger Decr(BigInteger val) => val--;
        public BigInteger Not(BigInteger val) => throw new NotImplementedException();

        public BigInteger Add(BigInteger a, BigInteger b) => a + b;
        public BigInteger Sub(BigInteger a, BigInteger b) => a - b;
        public BigInteger Mul(BigInteger a, BigInteger b) => a * b;
        public BigInteger Div(BigInteger a, BigInteger b) => a / b;

        public BigInteger And(BigInteger a, BigInteger b) => a & b;
        public BigInteger Or(BigInteger a, BigInteger b) => a | b;
        public BigInteger Xor(BigInteger a, BigInteger b) => a ^ b;
        public BigInteger Complement(BigInteger val) => ~val;

        public bool Eq(BigInteger a, BigInteger b) => a == b;
        public bool Neq(BigInteger a, BigInteger b) => a != b;

        public bool Lt(BigInteger a, BigInteger b) => a < b;
        public bool Gt(BigInteger a, BigInteger b) => a > b;
        public bool Lte(BigInteger a, BigInteger b) => a <= b;
        public bool Gte(BigInteger a, BigInteger b) => a >= b;
        
        public BigInteger Shl(BigInteger val, int cnt) => val << cnt;
        public BigInteger Shr(BigInteger val, int cnt) => val >> cnt;

        public BigInteger Mod(BigInteger a, BigInteger b) => a % b;
    }
}
