using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CTFLibrary
{
    public class Matrix<T, OpT> where OpT : IOperator<T>
    {
        static OpT Op = default(OpT);
        static T TZero = default(T);
        static T TOne = Op.Incr(TZero);
        public int Height { get; }
        public int Width { get; }
        T[] data;
        public Matrix(int height, int width)
        {
            data = new T[height * width];
            Height = height;
            Width = width;
        }
        public T this[int i, int j]
        {
            get { return data[i * Width + j]; }
            set { data[i * Width + j] = value; }
        }
        public static Matrix<T, OpT> DiagonalMatrix(int n, T val)
        {
            var res = new Matrix<T, OpT>(n, n);
            for (int i = 0; i < n; i++) res[i, i] = val;
            return res;
        }
        public static Matrix<T, OpT> Add(Matrix<T, OpT> a, Matrix<T, OpT> b)
        {
            var res = new Matrix<T, OpT>(a.Height, a.Width);
            for (int i = 0; i < a.Height; i++) for (int j = 0; j < a.Width; j++) res[i, j] = Op.Add(a[i, j], b[i, j]);
            return res;
        }
        public static Matrix<T, OpT> Sub(Matrix<T, OpT> a, Matrix<T, OpT> b)
        {
            var res = new Matrix<T, OpT>(a.Height, a.Width);
            for (int i = 0; i < a.Height; i++) for (int j = 0; j < a.Width; j++) res[i, j] = Op.Sub(a[i, j], b[i, j]);
            return res;
        }
        public static Matrix<T, OpT> Mul(Matrix<T, OpT> a, Matrix<T, OpT> b)
        {
            var res = new Matrix<T, OpT>(a.Height, b.Width);
            for (int i = 0; i < a.Height; i++) for (int j = 0; j < b.Width; j++) for (int k = 0; k < a.Width; k++) res[i, j] = Op.Add(res[i, j], Op.Mul(a[i, k], b[k, j]));
            return res;
        }
        public static Matrix<T, OpT> operator +(Matrix<T, OpT> a, Matrix<T, OpT> b) => Add(a, b);
        public static Matrix<T, OpT> operator -(Matrix<T, OpT> a, Matrix<T, OpT> b) => Sub(a, b);
        public static Matrix<T, OpT> operator *(Matrix<T, OpT> a, Matrix<T, OpT> b) => Mul(a, b);

        public Matrix<T, OpT> Pow(long m)
        {
            Matrix<T, OpT> pow = this;
            Matrix<T, OpT> res = DiagonalMatrix(Height, TOne);
            while (m > 0)
            {
                if ((m & 1) == 1) res *= pow;
                pow *= pow;
                m >>= 1;
            }
            return res;
        }
    }
}
