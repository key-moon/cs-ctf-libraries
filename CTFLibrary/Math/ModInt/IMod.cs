using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace CTFLibrary
{
    public interface IMod
    {
        public BigInteger Mod { get; }
    }
    public struct StaticMod998244353 { public BigInteger Mod => 998244353; }
    public struct StaticMod1000000007 { public BigInteger Mod => 1000000007; }

    public struct DynamicMod1 : IMod { public static BigInteger MOD; public BigInteger Mod => MOD; }
    public struct DynamicMod2 : IMod { public static BigInteger MOD; public BigInteger Mod => MOD; }
    public struct DynamicMod3 : IMod { public static BigInteger MOD; public BigInteger Mod => MOD; }
    public struct DynamicMod4 : IMod { public static BigInteger MOD; public BigInteger Mod => MOD; }
    public struct DynamicMod5 : IMod { public static BigInteger MOD; public BigInteger Mod => MOD; }
    public struct DynamicMod6 : IMod { public static BigInteger MOD; public BigInteger Mod => MOD; }
    public struct DynamicMod7 : IMod { public static BigInteger MOD; public BigInteger Mod => MOD; }
    public struct DynamicMod8 : IMod { public static BigInteger MOD; public BigInteger Mod => MOD; }
    public struct DynamicMod9 : IMod { public static BigInteger MOD; public BigInteger Mod => MOD; }
}
