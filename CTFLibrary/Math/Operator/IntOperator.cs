using System;

namespace CTFLibrary
{
    public struct IntOperator : IOperator<int>
    {
        public int Neg(int val) => -val;
        public int Incr(int val) => val++;
        public int Decr(int val) => val--;
        public int Not(int val) => throw new NotImplementedException();

        public int Add(int a, int b) => a + b;
        public int Sub(int a, int b) => a - b;
        public int Mul(int a, int b) => a * b;
        public int Div(int a, int b) => a / b;

        public int And(int a, int b) => a & b;
        public int Or(int a, int b) => a | b;
        public int Xor(int a, int b) => a ^ b;
        public int Complement(int val) => ~val;

        public bool Eq(int a, int b) => a == b;
        public bool Neq(int a, int b) => a != b;

        public bool Lt(int a, int b) => a < b;
        public bool Gt(int a, int b) => a > b;
        public bool Lte(int a, int b) => a <= b;
        public bool Gte(int a, int b) => a >= b;
        
        public int Shl(int val, int cnt) => val << cnt;
        public int Shr(int val, int cnt) => val >> cnt;

        public int Mod(int a, int b) => a % b;
    }
}
