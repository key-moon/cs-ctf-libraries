using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CTFLibrary
{
    public partial class Symmetric
    {
        public static Symmetric operator *(Symmetric a, Symmetric b) => Operate(a, b);
        public static Symmetric operator /(Symmetric a, Symmetric b) => Operate(a, b.Inverse());

        public static sbyte[] operator *(sbyte[] a, Symmetric b) => Operate(a, b);
        public static byte[] operator *(byte[] a, Symmetric b) => Operate(a, b);
        public static short[] operator *(short[] a, Symmetric b) => Operate(a, b);
        public static ushort[] operator *(ushort[] a, Symmetric b) => Operate(a, b);
        public static int[] operator *(int[] a, Symmetric b) => Operate(a, b);
        public static uint[] operator *(uint[] a, Symmetric b) => Operate(a, b);
        public static long[] operator *(long[] a, Symmetric b) => Operate(a, b);
        public static ulong[] operator *(ulong[] a, Symmetric b) => Operate(a, b);
        public static BigInteger[] operator *(BigInteger[] a, Symmetric b) => Operate(a, b);
        public static string[] operator *(string[] a, Symmetric b) => Operate(a, b);
        public static Bytes[] operator *(Bytes[] a, Symmetric b) => Operate(a, b);
        public static Bytes operator *(Bytes bytes, Symmetric b) => Operate(bytes.ToByteArray(), b);

        public static sbyte[] operator /(sbyte[] a, Symmetric b) => Operate(a, b.Inverse());
        public static byte[] operator /(byte[] a, Symmetric b) => Operate(a, b.Inverse());
        public static short[] operator /(short[] a, Symmetric b) => Operate(a, b.Inverse());
        public static ushort[] operator /(ushort[] a, Symmetric b) => Operate(a, b.Inverse());
        public static int[] operator /(int[] a, Symmetric b) => Operate(a, b.Inverse());
        public static uint[] operator /(uint[] a, Symmetric b) => Operate(a, b.Inverse());
        public static long[] operator /(long[] a, Symmetric b) => Operate(a, b.Inverse());
        public static ulong[] operator /(ulong[] a, Symmetric b) => Operate(a, b.Inverse());
        public static BigInteger[] operator /(BigInteger[] a, Symmetric b) => Operate(a, b.Inverse());
        public static string[] operator /(string[] a, Symmetric b) => Operate(a, b.Inverse());
        public static Bytes[] operator /(Bytes[] a, Symmetric b) => Operate(a, b.Inverse());
        public static Bytes operator /(Bytes bytes, Symmetric b) => Operate(bytes.ToByteArray(), b.Inverse());
        
        public static T[] Operate<T>(T[] arr, Symmetric op)
        {
            if (arr.Length != op.Size) throw new ArgumentException($"operator size should be equal with array length({arr.Length})", nameof(op));
            T[] res = new T[arr.Length];
            for (int i = 0; i < arr.Length; i++) res[op[i]] = arr[i];
            return res;
        }
        public static Symmetric Operate(Symmetric a, Symmetric b)
        {
            Trace.Assert(a.Size == b.Size);
            int size = a.Size;
            int[] res = new int[size];
            for (int i = 0; i < size; i++) res[i] = b[a[i]];
            return new Symmetric(res);
        }
    }
}

