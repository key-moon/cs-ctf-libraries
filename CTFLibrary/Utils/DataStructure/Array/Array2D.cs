using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CTFLibrary
{
    public class Array2D<T> : IEnumerable<T>
    {
        public int Width;
        public int Height;
        public T[] Data;
        public T this[int i, int j]
        {
            get => Data[i * Width + j];
            set => Data[i * Width + j] = value;
        }
        public Array2D(int w, int h)
        {
            Width = w;
            Height = h;
            Data = new T[w * h];
        }
        public Array2D(Array2D<T> data) : this(data.Width, data.Height)
        {
            Array.Copy(data.Data, Data, Data.Length);
        }

        public IEnumerator<T> GetEnumerator() => Data.AsEnumerable().GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => Data.GetEnumerator();
    }
}
