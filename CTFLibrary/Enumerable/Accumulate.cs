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
        public static IEnumerable<int> Accumulate(this IEnumerable<int> enumerate)
            => Accumulate<int, IntOperator>(enumerate, 0);
        public static IEnumerable<long> Accumulate(this IEnumerable<long> enumerate)
            => Accumulate<long, LongOperator>(enumerate, 0L);
        public static IEnumerable<float> Accumulate(this IEnumerable<float> enumerate)
            => Accumulate<float, FloatOperator>(enumerate, 0.0f);
        public static IEnumerable<double> Accumulate(this IEnumerable<double> enumerate)
            => Accumulate<double, DoubleOperator>(enumerate, 0.0);
        public static IEnumerable<BigInteger> Accumulate(this IEnumerable<BigInteger> enumerate)
            => Accumulate<BigInteger, BigIntegerOperator>(enumerate, BigInteger.Zero);
        public static IEnumerable<ModInt<ModT>> Accumulate<ModT>(this IEnumerable<ModInt<ModT>> enumerate) where ModT : IMod
            => Accumulate<ModInt<ModT>, ModIntOperator<ModT>>(enumerate, new ModInt<ModT>(0));

        public static IEnumerable<T> Accumulate<T, OpT>(this IEnumerable<T> enumerate, T init = default) where OpT : IOperator<T>
        {
            yield return init;
            var op = default(OpT);
            foreach (var item in enumerate)
            {
                init = op.Add(init, item);
                yield return init;
            }
        }
    }
}
