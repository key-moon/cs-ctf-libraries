using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace CTFLibrary
{
    public static partial class MyEnumerable
    {

        public static IEnumerable<T[]> Product<T>(this IEnumerable<T> enumerate, int cnt)
        {
            if (cnt == 0)
            {
                yield return new T[0];
                yield break;
            }

            var arr = enumerate.ToArray();
            foreach (var prod in arr.Product(cnt - 1))
                foreach (var item in arr)
                    yield return prod.Append(item).ToArray();
        }

        public static IEnumerable<(T, T)> Product2<T>(this IEnumerable<T> enumerate)
        {
            var arr = enumerate.ToArray();
            for (int i = 0; i < arr.Length; i++)
                for (int j = 0; j < arr.Length; j++)
                    yield return (arr[i], arr[j]);
        }
        public static IEnumerable<(T1, T2)> Product<T1, T2>(this IEnumerable<T1> enumerate1, IEnumerable<T2> enumerate2)
        {
            var arr1 = enumerate1.ToArray();
            var arr2 = enumerate2.ToArray();
            for (int i = 0; i < arr1.Length; i++)
                for (int j = 0; j < arr2.Length; j++)
                    yield return (arr1[i], arr2[j]);
        }
        public static IEnumerable<(T, T, T)> Product3<T>(this IEnumerable<T> enumerate)
        {
            var arr = enumerate.ToArray();
            for (int i = 0; i < arr.Length; i++)
                for (int j = 0; j < arr.Length; j++)
                    for (int k = 0; k < arr.Length; k++)
                        yield return (arr[i], arr[j], arr[k]);
        }
        public static IEnumerable<(T1, T2, T3)> Product<T1, T2, T3>(this IEnumerable<T1> enumerate1, IEnumerable<T2> enumerate2, IEnumerable<T3> enumerate3)
        {
            var arr1 = enumerate1.ToArray();
            var arr2 = enumerate2.ToArray();
            var arr3 = enumerate3.ToArray();
            for (int i = 0; i < arr1.Length; i++)
                for (int j = 0; j < arr2.Length; j++)
                    for (int k = 0; k < arr3.Length; k++)
                        yield return (arr1[i], arr2[j], arr3[k]);
        }
        public static IEnumerable<(T, T, T, T)> Product4<T>(this IEnumerable<T> enumerate)
        {
            var arr = enumerate.ToArray();
            for (int i1 = 0; i1 < arr.Length; i1++)
                for (int i2 = 0; i2 < arr.Length; i2++)
                    for (int i3 = 0; i3 < arr.Length; i3++)
                        for (int i4 = 0; i4 < arr.Length; i4++)
                            yield return (arr[i1], arr[i2], arr[i3], arr[i4]);
        }
        public static IEnumerable<(T1, T2, T3, T4)> Product<T1, T2, T3, T4>(this IEnumerable<T1> enumerate1, IEnumerable<T2> enumerate2, IEnumerable<T3> enumerate3, IEnumerable<T4> enumerate4)
        {
            var arr1 = enumerate1.ToArray();
            var arr2 = enumerate2.ToArray();
            var arr3 = enumerate3.ToArray();
            var arr4 = enumerate4.ToArray();
            for (int i1 = 0; i1 < arr1.Length; i1++)
                for (int i2 = 0; i2 < arr2.Length; i2++)
                    for (int i3 = 0; i3 < arr3.Length; i3++)
                        for (int i4 = 0; i4 < arr4.Length; i4++)
                            yield return (arr1[i1], arr2[i2], arr3[i3], arr4[i4]);
        }
        public static IEnumerable<(T, T, T, T, T)> Product5<T>(this IEnumerable<T> enumerate)
        {
            var arr = enumerate.ToArray();
            for (int i1 = 0; i1 < arr.Length; i1++)
                for (int i2 = 0; i2 < arr.Length; i2++)
                    for (int i3 = 0; i3 < arr.Length; i3++)
                        for (int i4 = 0; i4 < arr.Length; i4++)
                            for (int i5 = 0; i5 < arr.Length; i5++)
                                yield return (arr[i1], arr[i2], arr[i3], arr[i4], arr[i5]);
        }
        public static IEnumerable<(T1, T2, T3, T4, T5)> Product<T1, T2, T3, T4, T5>(this IEnumerable<T1> enumerate1, IEnumerable<T2> enumerate2, IEnumerable<T3> enumerate3, IEnumerable<T4> enumerate4, IEnumerable<T5> enumerate5)
        {
            var arr1 = enumerate1.ToArray();
            var arr2 = enumerate2.ToArray();
            var arr3 = enumerate3.ToArray();
            var arr4 = enumerate4.ToArray();
            var arr5 = enumerate5.ToArray();
            for (int i1 = 0; i1 < arr1.Length; i1++)
                for (int i2 = 0; i2 < arr2.Length; i2++)
                    for (int i3 = 0; i3 < arr3.Length; i3++)
                        for (int i4 = 0; i4 < arr4.Length; i4++)
                            for (int i5 = 0; i5 < arr4.Length; i5++)
                                yield return (arr1[i1], arr2[i2], arr3[i3], arr4[i4], arr5[i5]);
        }
    }
}
