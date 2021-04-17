using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;

namespace CTFLibrary
{
    public static class MyPath
    {
        public static readonly string Home = $"C:/Users/{Environment.UserName}";
        public static readonly string Document = $"{Home}/Documents";
        public static readonly string Desktop = $"{Home}/Desktop";
        public static readonly string Downloads = $"{Home}/Downloads";
        public static readonly string AppData = $"{Home}/AppData";

        public static readonly string Bin = $"{Document}/bin";

        public static readonly string MSieve = $"{Bin}/msieve/msieve.exe";
        public static readonly string Fplll = $"{Bin}/fplll/fplll/fplll";
        
        public static readonly string SageBash = $"{AppData}/Local/SageMath 9.0/runtime/bin/bash.exe";
    }
}
