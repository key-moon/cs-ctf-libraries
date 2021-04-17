using System;
using System.IO;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CTFLibrary
{
    public static partial class MyMath
    {
        public enum FactorMethod
        {
            Default = 0,
            Native,
            FactorDB,
            MSieve
        }
        public static FactorMethod DefaultMethod = FactorMethod.MSieve;
        public static int[] Factor(this int value, FactorMethod method = FactorMethod.Default)
        {
            switch (method == default ? DefaultMethod : method)
            {
                case FactorMethod.Native: throw new NotImplementedException();
                case FactorMethod.FactorDB: return value.FactorWithFactorDB();
                case FactorMethod.MSieve: return value.FactorWithMSieve();
                default: throw new Exception();
            }
        }
        public static long[] Factor(this long value, FactorMethod method = FactorMethod.Default)
        {
            switch (method == default ? DefaultMethod : method)
            {
                case FactorMethod.Native: throw new NotImplementedException();
                case FactorMethod.FactorDB: return value.FactorWithFactorDB();
                case FactorMethod.MSieve: return value.FactorWithMSieve();
                default: throw new Exception();
            }
        }
        public static BigInteger[] Factor(this BigInteger value, FactorMethod method = FactorMethod.Default)
        {
            switch (method == default ? DefaultMethod : method)
            {
                case FactorMethod.Native: throw new NotImplementedException();
                case FactorMethod.FactorDB: return value.FactorWithFactorDB().Item1;
                case FactorMethod.MSieve: return value.FactorWithMSieve();
                default: throw new Exception();
            }
        }
    }
}

