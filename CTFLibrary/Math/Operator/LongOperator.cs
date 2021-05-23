using System;

namespace CTFLibrary
{
    public struct LongOperator : IOperator<long>
    {
        public long Neg(long val) => -val;
        public long Incr(long val) => val++;
        public long Decr(long val) => val--;
        public long Not(long val) => throw new NotImplementedException();

        public long Add(long a, long b) => a + b;
        public long Sub(long a, long b) => a - b;
        public long Mul(long a, long b) => a * b;
        public long Div(long a, long b) => a / b;

        public long And(long a, long b) => a & b;
        public long Or(long a, long b) => a | b;
        public long Xor(long a, long b) => a ^ b;
        public long Complement(long val) => ~val;

        public bool Eq(long a, long b) => a == b;
        public bool Neq(long a, long b) => a != b;

        public bool Lt(long a, long b) => a < b;
        public bool Gt(long a, long b) => a > b;
        public bool Lte(long a, long b) => a <= b;
        public bool Gte(long a, long b) => a >= b;
        
        public long Shl(long val, int cnt) => val << cnt;
        public long Shr(long val, int cnt) => val >> cnt;

        public long Mod(long a, long b) => a % b;
    }
}
