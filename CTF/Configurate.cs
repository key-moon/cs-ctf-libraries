using System;
using System.IO;
using System.Diagnostics;
using System.Collections.Generic;
using System.Text;

using CTFLibrary;

static class Path
{
    public static readonly string Home = $"C:/Users/{Environment.UserName}";
    public static readonly string Document = $"{Home}/Documents";
    public static readonly string Desktop = $"{Home}/Desktop";
    public static readonly string Downloads = $"{Home}/Downloads";
    public static readonly string AppData = $"{Home}/AppData";
    public static readonly string Bin = $"{Document}/bin";

    public static string MSieve = $"{Bin}/msieve/msieve.exe";
    public static string Fplll = $"{Bin}/fplll/fplll/fplll";
    public static string SageBash = $"{AppData}/Local/SageMath 9.0/runtime/bin/bash.exe";
}
static class Config
{
    public static void Init()
    {
        Environment.CurrentDirectory = Path.Desktop;
        BinPath.Fplll = Path.Fplll;
        BinPath.MSieve = Path.MSieve;
        BinPath.SageBash = Path.SageBash;
    }
}
