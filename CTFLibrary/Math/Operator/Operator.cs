using System.Reflection;

namespace CTFLibrary
{
    public struct Operator<T> : IOperator<T>
    {
        static MethodInfo NegInfo;
        static MethodInfo IncrInfo;
        static MethodInfo DecrInfo;
        static MethodInfo NotInfo;

        static MethodInfo AddInfo;
        static MethodInfo SubInfo;
        static MethodInfo MulInfo;
        static MethodInfo DivInfo;
        
        static MethodInfo AndInfo;
        static MethodInfo OrInfo;
        static MethodInfo XorInfo;
        static MethodInfo ComplementInfo;
        
        static MethodInfo EqInfo;
        static MethodInfo NeqInfo;
        static MethodInfo LtInfo;
        static MethodInfo GtInfo;
        static MethodInfo LteInfo;
        static MethodInfo GteInfo;
        
        static MethodInfo ShlInfo;
        static MethodInfo ShrInfo;
        
        static MethodInfo ModInfo;
        static Operator()
        {
            NegInfo = typeof(T).GetMethod("op_UnaryNegation", BindingFlags.Static | BindingFlags.Public);
            IncrInfo = typeof(T).GetMethod("op_Increment", BindingFlags.Static | BindingFlags.Public);
            DecrInfo = typeof(T).GetMethod("op_Decrement", BindingFlags.Static | BindingFlags.Public);
            NotInfo = typeof(T).GetMethod("op_LogicalNot", BindingFlags.Static | BindingFlags.Public);
            
            AddInfo = typeof(T).GetMethod("op_Addition", BindingFlags.Static | BindingFlags.Public);
            SubInfo = typeof(T).GetMethod("op_Subtraction", BindingFlags.Static | BindingFlags.Public);
            MulInfo = typeof(T).GetMethod("op_Multiply", BindingFlags.Static | BindingFlags.Public);
            DivInfo = typeof(T).GetMethod("op_Division", BindingFlags.Static | BindingFlags.Public);
            
            AndInfo = typeof(T).GetMethod("op_BitwiseAnd", BindingFlags.Static | BindingFlags.Public);
            OrInfo = typeof(T).GetMethod("op_BitwiseOr", BindingFlags.Static | BindingFlags.Public);
            XorInfo = typeof(T).GetMethod("op_ExclusiveOr", BindingFlags.Static | BindingFlags.Public);
            ComplementInfo = typeof(T).GetMethod("op_OnesComplement", BindingFlags.Static | BindingFlags.Public);

            EqInfo = typeof(T).GetMethod("op_Equality", BindingFlags.Static | BindingFlags.Public);
            NeqInfo = typeof(T).GetMethod("op_Inequality", BindingFlags.Static | BindingFlags.Public);
            LtInfo = typeof(T).GetMethod("op_LessThan", BindingFlags.Static | BindingFlags.Public);
            GtInfo = typeof(T).GetMethod("op_GreaterThan", BindingFlags.Static | BindingFlags.Public);
            LteInfo = typeof(T).GetMethod("op_LessThanOrEqual", BindingFlags.Static | BindingFlags.Public);
            GteInfo = typeof(T).GetMethod("op_GreaterThanOrEqual", BindingFlags.Static | BindingFlags.Public);

            ShrInfo = typeof(T).GetMethod("op_RightShift", BindingFlags.Static | BindingFlags.Public);
            ShlInfo = typeof(T).GetMethod("op_LeftShift", BindingFlags.Static | BindingFlags.Public);

            ModInfo = typeof(T).GetMethod("op_Modulus", BindingFlags.Static | BindingFlags.Public);
        }

        public T Neg(T a) => (T)NegInfo.Invoke(null, new object[] { a });
        public T Incr(T a) => (T)IncrInfo.Invoke(null, new object[] { a });
        public T Decr(T a) => (T)DecrInfo.Invoke(null, new object[] { a });
        public T Not(T a) => (T)NotInfo.Invoke(null, new object[] { a });

        public T Add(T a, T b) => (T)AddInfo.Invoke(null, new object[] { a, b });
        public T Sub(T a, T b) => (T)SubInfo.Invoke(null, new object[] { a, b });
        public T Mul(T a, T b) => (T)MulInfo.Invoke(null, new object[] { a, b });
        public T Div(T a, T b) => (T)DivInfo.Invoke(null, new object[] { a, b });

        public T And(T a, T b) => (T)AndInfo.Invoke(null, new object[] { a, b });
        public T Or(T a, T b) => (T)OrInfo.Invoke(null, new object[] { a, b });
        public T Xor(T a, T b) => (T)XorInfo.Invoke(null, new object[] { a, b });
        public T Complement(T a) => (T)ComplementInfo.Invoke(null, new object[] { a });
        
        public bool Eq(T a, T b) => (bool)EqInfo.Invoke(null, new object[] { a, b });
        public bool Neq(T a, T b) => (bool)NeqInfo.Invoke(null, new object[] { a, b });
        public bool Lt(T a, T b) => (bool)LtInfo.Invoke(null, new object[] { a, b });
        public bool Gt(T a, T b) => (bool)GtInfo.Invoke(null, new object[] { a, b });
        public bool Lte(T a, T b) => (bool)LteInfo.Invoke(null, new object[] { a, b });
        public bool Gte(T a, T b) => (bool)GteInfo.Invoke(null, new object[] { a, b });
        
        public T Shr(T val, int cnt) => (T)ShrInfo.Invoke(null, new object[] { val, cnt });
        public T Shl(T val, int cnt) => (T)ShlInfo.Invoke(null, new object[] { val, cnt });

        public T Mod(T a, T b) => (T)ModInfo.Invoke(null, new object[] { a, b });
    }
}
