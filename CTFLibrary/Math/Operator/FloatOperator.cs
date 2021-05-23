using System;

namespace CTFLibrary
{
    public struct FloatOperator : IOperator<float>
    {
        public float Neg(float val) => -val;
        public float Incr(float val) => val++;
        public float Decr(float val) => val--;
        public float Not(float val) => throw new NotImplementedException();

        public float Add(float a, float b) => a + b;
        public float Sub(float a, float b) => a - b;
        public float Mul(float a, float b) => a * b;
        public float Div(float a, float b) => a / b;

        public float And(float a, float b) => throw new NotImplementedException();
        public float Or(float a, float b) => throw new NotImplementedException();
        public float Xor(float a, float b) => throw new NotImplementedException();
        public float Complement(float val) => throw new NotImplementedException();

        public bool Eq(float a, float b) => a == b;
        public bool Neq(float a, float b) => a != b;

        public bool Lt(float a, float b) => a < b;
        public bool Gt(float a, float b) => a > b;
        public bool Lte(float a, float b) => a <= b;
        public bool Gte(float a, float b) => a >= b;
        
        public float Shl(float val, int cnt) => throw new NotImplementedException();
        public float Shr(float val, int cnt) => throw new NotImplementedException();

        public float Mod(float a, float b) => a % b;
    }
}
