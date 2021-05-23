namespace CTFLibrary
{
    public interface IOperator<T>
    {
        public T Neg(T val);
        public T Incr(T val);
        public T Decr(T val);
        public T Not(T val);
        public T Add(T a, T b);
        public T Sub(T a, T b);
        public T Mul(T a, T b);
        public T Div(T a, T b);
        public T And(T a, T b);
        public T Or(T a, T b);
        public T Xor(T a, T b);
        public T Complement(T val);
        public bool Eq(T a, T b);
        public bool Neq(T a, T b);
        public bool Lt(T a, T b);
        public bool Gt(T a, T b);
        public bool Lte(T a, T b);
        public bool Gte(T a, T b);
        public T Shl(T val, int cnt);
        public T Shr(T val, int cnt);
        public T Mod(T a, T b);
    }
}
