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
        public static (int[] compressed, Dictionary<T, int> dic, T[] arr) Compress<T>(this IEnumerable<T> enumerate)
        {
            var elems = enumerate.ToArray();
            var arr = elems.Distinct().OrderBy(x => x).ToArray();
            var compressed = arr.Select((elem, ind) => (elem, ind)).ToDictionary(x => x.elem, x => x.ind);
            return (elems.Select(x => compressed[x]).ToArray(), compressed, arr);
        }
    }
}
