static class Path
{
    public static readonly string Home = $"C:/Users/{Environment.UserName}";
    public static readonly string Document = $"{Home}/Documents";
    public static readonly string Desktop = $"{Home}/Desktop";
    public static readonly string Downloads = $"{Home}/Downloads";
    public static readonly string AppData = $"{Home}/AppData";
    public static readonly string CTFDir = $"{Home}/CTF";
    public static readonly string Bin = $"{CTFDir}/bin";

    public static string MSieve = $"{Bin}/msieve/msieve.exe";
    public static string Fplll = $"{Bin}/fplll/fplll/fplll";
    public static string WordFreq = $"{Bin}/word_freq.csv";
    public static string SageBash = $"{AppData}/Local/SageMath 9.0/runtime/bin/bash.exe";
    public static string RockYou = $"{Bin}/rockyou.txt";
    public static string PythonDLL = $"{Bin}/Python38/python38.dll";
}

static class Config
{
    public static void Init()
    {
        Runtime.PythonDLL = Path.PythonDLL;
        Environment.CurrentDirectory = Path.Desktop;
        BinPath.WordFreqList = Path.WordFreq;
        BinPath.Fplll = Path.Fplll;
        BinPath.MSieve = Path.MSieve;
        BinPath.SageBash = Path.SageBash;
        BinPath.RockYou = Path.RockYou;
    }
}
