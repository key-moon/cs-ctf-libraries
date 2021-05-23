using System;

namespace CTFLibrary
{
    public struct ModIntOperator<ModT> : IOperator<ModInt<ModT>> where ModT : IMod
    {
        public ModInt<ModT> Neg(ModInt<ModT> val) => -val;
        public ModInt<ModT> Incr(ModInt<ModT> val) => val++;
        public ModInt<ModT> Decr(ModInt<ModT> val) => val--;
        public ModInt<ModT> Not(ModInt<ModT> val) => throw new NotImplementedException();

        public ModInt<ModT> Add(ModInt<ModT> a, ModInt<ModT> b) => a + b;
        public ModInt<ModT> Sub(ModInt<ModT> a, ModInt<ModT> b) => a - b;
        public ModInt<ModT> Mul(ModInt<ModT> a, ModInt<ModT> b) => a * b;
        public ModInt<ModT> Div(ModInt<ModT> a, ModInt<ModT> b) => a / b;

        public ModInt<ModT> And(ModInt<ModT> a, ModInt<ModT> b) => throw new NotImplementedException();
        public ModInt<ModT> Or(ModInt<ModT> a, ModInt<ModT> b) => throw new NotImplementedException();
        public ModInt<ModT> Xor(ModInt<ModT> a, ModInt<ModT> b) => throw new NotImplementedException();
        public ModInt<ModT> Complement(ModInt<ModT> val) => throw new NotImplementedException();

        public bool Eq(ModInt<ModT> a, ModInt<ModT> b) => a == b;
        public bool Neq(ModInt<ModT> a, ModInt<ModT> b) => a != b;

        public bool Lt(ModInt<ModT> a, ModInt<ModT> b) => throw new NotImplementedException();
        public bool Gt(ModInt<ModT> a, ModInt<ModT> b) => throw new NotImplementedException();
        public bool Lte(ModInt<ModT> a, ModInt<ModT> b) => throw new NotImplementedException();
        public bool Gte(ModInt<ModT> a, ModInt<ModT> b) => throw new NotImplementedException();

        public ModInt<ModT> Shl(ModInt<ModT> val, int cnt) => throw new NotImplementedException();
        public ModInt<ModT> Shr(ModInt<ModT> val, int cnt) => throw new NotImplementedException();

        public ModInt<ModT> Mod(ModInt<ModT> a, ModInt<ModT> b) => throw new NotImplementedException();
    }
}
