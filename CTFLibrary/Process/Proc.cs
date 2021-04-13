using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime;
using System.Diagnostics;

namespace CTFLibrary
{
    public static partial class ProcessUtil
    {
        public static Process StartWithRedirects(
            string fileName,
            string arg,
            bool redirectStandardInput = true,
            bool redirectStandardOutput = true,
            bool redirectStandardError = true
        )
        {
            var info = new ProcessStartInfo()
            {
                FileName = fileName,
                Arguments = arg,
                RedirectStandardInput = redirectStandardInput,
                RedirectStandardOutput = redirectStandardOutput,
                RedirectStandardError = redirectStandardError
            };
            return Process.Start(info);
        }
        public static (string output, string error) Exec(string fileName, string arg, string input = null)
        {
            using var pc = StartWithRedirects(fileName, arg);
            if (input is not null) pc.StandardInput.Write(input);
            pc.WaitForExit();
            return (pc.StandardOutput.ReadToEnd(), pc.StandardError.ReadToEnd());
        }
    }
}
