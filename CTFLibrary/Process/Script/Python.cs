using System;
using System.IO;
using System.Collections.Generic;
using System.Text;
using System.Runtime;
using System.Diagnostics;

namespace CTFLibrary
{
    public static partial class ProcessUtil
    {
        public static Process StartPython(string script, string args = null, string input = null)
        {
            var scriptPath = $"{Path.GetTempFileName()}.py";
            File.WriteAllText(scriptPath, script);
            if (args is not null) scriptPath = $"{scriptPath} {args}";
            var pc = Start("python", scriptPath);
            if (input is not null) pc.StandardInput.Write(input);
            return pc;
        }
        public static (string output, string error) ExecPython(string script, string args = null, string input = null)
        {
            using var pc = StartPython(script, args, input);
            pc.WaitForExit();
            return (pc.StandardOutput.ReadToEnd(), pc.StandardError.ReadToEnd());
        }
    }
}
