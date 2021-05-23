using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CTFLibrary
{
    public class Array3D<T> : IEnumerable<T>
    {
        public int Size1;
        public int Size2;
        public int Size3;
        public T[] Data;
        public T this[int i, int j, int k]
        {
            get => Data[(i * Size1 + j) * Size2 + k];
            set => Data[(i * Size1 + j) * Size2 + k] = value;
        }
        public Array3D(int size1, int size2, int size3)
        {
            Size1 = size1;
            Size2 = size2;
            Size3 = size3;
            Data = new T[size1 * size2 * size3];
        }
        public Array3D(Array3D<T> data) : this(data.Size1, data.Size2, data.Size3)
        {
            Array.Copy(data.Data, Data, Data.Length);
        }

        public IEnumerator<T> GetEnumerator() => Data.AsEnumerable().GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => Data.GetEnumerator();
    }
}
