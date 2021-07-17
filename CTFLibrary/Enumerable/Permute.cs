using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CTFLibrary
{
    public static partial class MyEnumerable
    {
        public static IEnumerable<T[]> Permutations<T>(this IEnumerable<T> array) => array.ToArray().Permutations();
        public static IEnumerable<T[]> Permutations<T>(this T[] array)
        {
            Dictionary<T, int> dic = new Dictionary<T, int>();
            int[] order = new int[array.Length];
            for (int i = 0; i < order.Length; i++)
            {
                if (!dic.ContainsKey(array[i])) dic.Add(array[i], dic.Count);
                order[i] = dic[array[i]];
            }
            var zipped = array.Zip(order).OrderBy(x => x.Second).ToArray();
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = zipped[i].First;
                order[i] = zipped[i].Second;
            }

            int index = 0;
            yield return array;
            while (true)
            {
                for (int i = array.Length - 1; i > 0; i--)
                {
                    if (order[i - 1].CompareTo(order[i]) >= 0) continue;
                    int j = Array.FindLastIndex(order, x => order[i - 1] < x);
                    Util.Swap(ref array[i - 1], ref array[j]);
                    Util.Swap(ref order[i - 1], ref order[j]);
                    Array.Reverse(array, i, array.Length - i);
                    Array.Reverse(order, i, order.Length - i);
                    yield return array;
                    goto end;
                }
                Array.Reverse(array, index, array.Length);
                Array.Reverse(order, index, order.Length);
                yield break;
                end:;
            }
        }
    }
}
