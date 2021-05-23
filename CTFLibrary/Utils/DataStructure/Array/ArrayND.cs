using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CTFLibrary
{
    public class ArrayND<T> : IEnumerable<T>
    {
        public readonly int N;
        public readonly int[] Sizes;
        public T[] Data;
        public T this[int[] ind]
        {
            get => Data[GetInd(ind)];
            set => Data[GetInd(ind)] = value;
        }
        int GetInd(int[] ind)
        {
            int res = 0;
            for (int i = 0; i < ind.Length; i++)
            {
                if (i != 0) res *= Sizes[i - 1];
                res += ind[i];
            }
            return res;
        }
        public ArrayND(int[] sizes)
        {
            Sizes = sizes.ToArray();
            int len = 1;
            for (int i = 0; i < sizes.Length; i++) len *= sizes[i];
            Data = new T[len];
        }
        public ArrayND(ArrayND<T> data) : this(data.Sizes)
        {
            Array.Copy(data.Data, Data, Data.Length);
        }

        public IEnumerator<T> GetEnumerator() => Data.AsEnumerable().GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => Data.GetEnumerator();
    }
}
