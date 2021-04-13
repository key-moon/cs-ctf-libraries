using System;
using System.IO;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Numerics;
using System.Text.Json;

namespace CTFLibrary
{
    public static partial class MyMath
    {
        static readonly string[] successResult = { "FF", "P", "Unit" };
        public static (BigInteger[], bool) FactorWithFactorDB(this BigInteger value, bool doFactorize = true, bool allowIncompleteFactorize = false)
        {
            if (doFactorize)HTTP.Get($"http://factordb.com/index.php?query={value}");
            var res = HTTP.GetJson<FactorDBQueryResult>($"http://factordb.com/api?query={value}");
            res.status = res.status.Trim('*');
            if (!allowIncompleteFactorize)
            {
                if (res.status == "C") throw new Exception($"Composite, no factors known: {value}");
                if (res.status == "CF") throw new Exception($"Composite, factors known: {res.FormattedFactors}");
                if (res.status == "Prp") throw new Exception($"Probably prime: {value}");
                if (res.status == "U") throw new Exception($"Unknown: {value}");
                if (res.status == "N") throw new Exception("This number is not in database (and was not added due to your settings)");
            }
            return (res.ExpandedFactors.Select(x => x.ParseToBigInteger()).ToArray(), successResult.Contains(res.status));
        }
        class FactorDBQueryResult
        {
            public string id { get; set; }
            public string status { get; set; }
            public object[][] factors { get; set; }
            public (string, int)[] ReTypedFactors => factors.Select(x => (((JsonElement)x[0]).GetString(), ((JsonElement)x[1]).GetInt32())).ToArray();
            public string FormattedFactors => string.Join("*", ReTypedFactors.Select(x => x.Item2 == 1 ? x.Item1 : $"({x.Item1}^{x.Item2})"));
            public string[] ExpandedFactors => ReTypedFactors.SelectMany(x => Enumerable.Repeat(x.Item1, x.Item2)).ToArray();
        }
    }
}

