using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace CTFLibrary
{
    public struct ModInt<ModT> where ModT : IMod
    {
        public static BigInteger Mod = default(ModT).Mod;
        BigInteger Data;
        public ModInt(BigInteger data) { if ((Data = data % Mod) < 0) Data += Mod; }
        public static ModInt<ModT> operator +(ModInt<ModT> a, ModInt<ModT> b)
        {
            BigInteger res = a.Data + b.Data;
            return new ModInt<ModT>() { Data = res >= Mod ? res - Mod : res };
        }
        public static ModInt<ModT> operator -(ModInt<ModT> a) => default(ModInt<ModT>) - a;
        public static ModInt<ModT> operator -(ModInt<ModT> a, ModInt<ModT> b)
        {
            BigInteger res = a.Data - b.Data;
            return new ModInt<ModT>() { Data = res < 0 ? res + Mod : res };
        }
        public static ModInt<ModT> operator ++(ModInt<ModT> a) => a + new ModInt<ModT>(1);
        public static ModInt<ModT> operator --(ModInt<ModT> a) => a - new ModInt<ModT>(1);
        public static ModInt<ModT> operator *(ModInt<ModT> a, ModInt<ModT> b)
            => new ModInt<ModT>() { Data = a.Data * b.Data % Mod };
        public static ModInt<ModT> operator /(ModInt<ModT> a, ModInt<ModT> b)
            => new ModInt<ModT>() { Data = a.Data * b.Data.Inverse(Mod) % Mod };
        public static bool operator ==(ModInt<ModT> a, ModInt<ModT> b) => a.Data == b.Data;
        public static bool operator !=(ModInt<ModT> a, ModInt<ModT> b) => a.Data != b.Data;
        public static explicit operator BigInteger(ModInt<ModT> val) => val.Data;
        public static explicit operator ModInt<ModT>(BigInteger val) => new ModInt<ModT>(val);
        public override string ToString() => Data.ToString();
        public override bool Equals(object obj) => (ModInt<ModT>)obj == this;
        public override int GetHashCode() => (int)Data;
    }
}
