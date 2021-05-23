using System;

namespace CTFLibrary
{
    public struct DoubleOperator : IOperator<double>
    {
        public double Neg(double val) => -val;
        public double Incr(double val) => val++;
        public double Decr(double val) => val--;
        public double Not(double val) => throw new NotImplementedException();

        public double Add(double a, double b) => a + b;
        public double Sub(double a, double b) => a - b;
        public double Mul(double a, double b) => a * b;
        public double Div(double a, double b) => a / b;

        public double And(double a, double b) => throw new NotImplementedException();
        public double Or(double a, double b) => throw new NotImplementedException();
        public double Xor(double a, double b) => throw new NotImplementedException();
        public double Complement(double val) => throw new NotImplementedException();

        public bool Eq(double a, double b) => a == b;
        public bool Neq(double a, double b) => a != b;

        public bool Lt(double a, double b) => a < b;
        public bool Gt(double a, double b) => a > b;
        public bool Lte(double a, double b) => a <= b;
        public bool Gte(double a, double b) => a >= b;
        
        public double Shl(double val, int cnt) => throw new NotImplementedException();
        public double Shr(double val, int cnt) => throw new NotImplementedException();

        public double Mod(double a, double b) => a % b;
    }
}
