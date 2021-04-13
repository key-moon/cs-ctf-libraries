using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;

namespace CTFLibrary
{
    public static class MyPath
    {
        public static readonly string Home = $"C:/Users/{Environment.UserName}";
        public static readonly string Document = $"{Environment.UserName}/Documents";
        public static readonly string Desktop = $"{Environment.UserName}/Desktop";
        public static readonly string Downloads = $"{Environment.UserName}/Downloads";

        public static readonly string Bin = $"{Document}/bin";

        public static readonly string MSieve = $"{Bin}/msieve/msieve.exe";
    }
}
