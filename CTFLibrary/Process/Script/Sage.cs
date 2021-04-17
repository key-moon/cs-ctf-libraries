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
        public static Process StartSage(string script, string args = null, string input = null)
        {
            var scriptPath = $"{Path.GetTempFileName()}.sage";
            File.WriteAllText(scriptPath, script);
            // "temprary" solution. set working directory to login shell is cleaner.
            var cmd = $"/tmp/{Path.GetFileName(scriptPath)}";
            if (args is not null) cmd += $" {args}";
            var pc = Start(MyPath.SageBash, $"--login -c '/opt/sagemath-9.0/sage {cmd}'");
            if (input is not null) pc.StandardInput.Write(input);
            return pc;
        }
        public static (string output, string error) ExecSage(string script, string args = null, string input = null)
        {
            using var pc = StartSage(script, args, input);
            pc.WaitForExit();
            return (pc.StandardOutput.ReadToEnd(), pc.StandardError.ReadToEnd());
        }
    }
}
