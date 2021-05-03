using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CTFLibrary
{
    public static partial class MyEnumerable
    {
        public static string Join<T>(this IEnumerable<T> a) => string.Concat(a);
        public static string Join<T>(this IEnumerable<T> a, char separator) => string.Join(separator, a);
        public static string Join<T>(this IEnumerable<T> a, string separator) => string.Join(separator, a);
    }
}
