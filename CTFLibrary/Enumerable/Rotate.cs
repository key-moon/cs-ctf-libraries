using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CTFLibrary
{
    public static partial class MyEnumerable
    {
        public static IEnumerable<T> RotateLeft<T>(this IEnumerable<T> a, int width)
        {
            var s = a.ToArray();
            width %= s.Length;
            if (width < 0) width += s.Length;
            return s.Skip(width).Concat(s.Take(width));
        }
        public static IEnumerable<T> RotateRight<T>(this IEnumerable<T> s, int width)
            => s.RotateLeft(-width);
    }
}
