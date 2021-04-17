using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CTFLibrary
{
    public static partial class MyEnumerable
    {
        public static IEnumerable<T[]> ChunkBy<T>(this T[] s, int size)
        {
            for (int i = 0; i < s.Length; i += size)
                yield return s.AsSpan().Slice(i, Math.Min(size, s.Length - i)).ToArray();
        }
    }
}
