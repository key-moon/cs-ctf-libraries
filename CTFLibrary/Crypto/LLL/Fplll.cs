using System;
using System.Linq;
using System.Numerics;
using System.Collections.Generic;
using System.Text;

namespace CTFLibrary
{
    public static partial class LatticeReduction
    {
        private static string CallFplll(string input, string flag)
        {
            var (res, err) = ProcessUtil.ExecOnWSL(BinPath.Fplll, flag, input, Encoding.ASCII);
            if (1 < err.Length) throw new Exception(err);
            return res;
        }
        private static string ConvertVector<T>(T[] a) => $"[{string.Join(" ", a)}]";
        private static string ConvertMatrix<T>(T[][] a) => $"[{string.Join("", a.Select(ConvertVector))}]";
        private static BigInteger[][] ParseToNumberMatrix(string a) => a.Split(']').Select(x => x.Trim('[', '\r', '\n', ' ')).Where(x => x.Length != 0).Select(x => x.Split().Select(x => x.ParseToBigInteger()).ToArray()).ToArray();
        private static BigInteger[] ParseToNumberVector(string a) => a.Trim('[', ']', '\r', '\n', ' ').Split(' ').Select(x => x.ParseToBigInteger()).ToArray();

        // TODO: add other option
        public static BigInteger[][] LLLWithFplll(
            this BigInteger[][] lattice,
            double delta = 0.99,
            double eta = 0.51
        ) => ParseToNumberMatrix(CallFplll(ConvertMatrix(lattice), $"-a lll -d {delta} -e {eta}"));

        // TODO: add stop condition option
        public static BigInteger[][] BKZWithFplll(
           this BigInteger[][] lattice,
           double blockSize = 10
        ) => ParseToNumberMatrix(CallFplll(ConvertMatrix(lattice), $"-a bkz -b {Math.Clamp(blockSize, 2, lattice.Length)}"));

        /*public static BigInteger[][] HKZByFplll(
           this BigInteger[][] lattice
        ) => ParseToNumberMatrix(CallFplll(ConvertMatrix(lattice), $"-a hkz"));*/

        public static BigInteger[] SVPWithFplll(
           this BigInteger[][] lattice
        ) => ParseToNumberVector(CallFplll(ConvertMatrix(lattice), $"-a svp"));

        public static BigInteger[] CVPWithFplll(
           this BigInteger[][] lattice,
           BigInteger[] vector
        ) => ParseToNumberVector(CallFplll($"{ConvertMatrix(lattice)}{ConvertVector(vector)}", $"-a cvp"));
    }
}
