﻿using System;
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
        public static BigInteger[] FactorWithMSieve(this BigInteger value)
        {
            if (310 <= value.ToString().Length) return FactorWithMSieveNFS(value);
            var (output, err) = ProcessUtil.Exec(MyPath.MSieve, $"-q {value}");
            if (err != "") throw new Exception(err);
            return output.Split('\n').Select(x => x.Split(':')).Where(x => 2 <= x.Length).Select(x => x[1].Trim().ParseToBigInteger()).ToArray();
        }
        public static BigInteger[] FactorWithMSieveNFS(this BigInteger value)
        {
            var iniFile = $"{Path.GetTempFileName()}.ini";
            File.WriteAllText(iniFile, value.ToString());
            var (output, err) = ProcessUtil.Exec(MyPath.MSieve, $"-q -n -i {iniFile}");
            if (err != "") throw new Exception(err);
            return output.Split('\n').Select(x => x.Split(':')).Where(x => 2 <= x.Length).Select(x => x[1].Trim().ParseToBigInteger()).ToArray();
        }
    }
}

