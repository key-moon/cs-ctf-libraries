using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using System.Numerics;
using System.Diagnostics.CodeAnalysis;

namespace CTFLibrary
{
    partial struct Bytes
    {
        public static Bytes operator +(Bytes a, Bytes b)
        {
            var len = Math.Min(a.Length, b.Length);
            var res = new byte[len];
            for (int i = 0; i < len; i++) res[i] = (byte)(a[i] + b[i]);
            return new Bytes(res);
        }
        public static Bytes operator -(Bytes a, Bytes b)
        {
            var len = Math.Min(a.Length, b.Length);
            var res = new byte[len];
            for (int i = 0; i < len; i++) res[i] = (byte)(a[i] - b[i]);
            return new Bytes(res);
        }

        public static Bytes operator ^(Bytes a, Bytes b)
        {
            var len = Math.Min(a.Length, b.Length);
            var res = new byte[len];
            for (int i = 0; i < len; i++) res[i] = (byte)(a[i] ^ b[i]);
            return new Bytes(res);
        }
        public static Bytes operator &(Bytes a, Bytes b)
        {
            var len = Math.Min(a.Length, b.Length);
            var res = new byte[len];
            for (int i = 0; i < len; i++) res[i] = (byte)(a[i] & b[i]);
            return new Bytes(res);
        }
        public static Bytes operator |(Bytes a, Bytes b)
        {
            var len = Math.Min(a.Length, b.Length);
            var res = new byte[len];
            for (int i = 0; i < len; i++) res[i] = (byte)(a[i] | b[i]);
            return new Bytes(res);
        }

        public static bool operator ==(Bytes a, Bytes b) => a._data.SequenceEqual(b._data);
        public static bool operator !=(Bytes a, Bytes b) => !a._data.SequenceEqual(b._data);

        public static implicit operator byte[](Bytes bytes) => bytes._data.ToArray();
        public static implicit operator Bytes(byte[] byteArray) => new Bytes(byteArray);

        public static implicit operator string(Bytes bytes) => bytes.ToString();
        public static implicit operator Bytes(string str) => str.ToBytes();

        public static implicit operator BigInteger(Bytes bytes) => bytes.ToBigInteger();
        public static implicit operator Bytes(BigInteger bigInt) => bigInt.ToBytes();

        public bool Equals(Bytes obj) => this == obj;
        public override bool Equals([NotNullWhen(true)] object obj) => obj is Bytes bytes && Equals(bytes);

        public override int GetHashCode() => _data.Sum(x => (int)x);
    }
}
