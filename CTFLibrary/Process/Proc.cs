using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime;
using System.Diagnostics;

namespace CTFLibrary
{
    public static partial class ProcessUtil
    {
        public static Process Start(
            string fileName,
            string arg = null,
            string workingDirectory = null,
            bool redirectStandardInput = true,
            bool redirectStandardOutput = true,
            bool redirectStandardError = true,
            Encoding enc = null
        )
        {
            var info = new ProcessStartInfo()
            {
                FileName = fileName,
                Arguments = arg,
                WorkingDirectory = workingDirectory,
                RedirectStandardInput = redirectStandardInput,
                RedirectStandardOutput = redirectStandardOutput,
                RedirectStandardError = redirectStandardError,
                StandardInputEncoding = enc ?? Encoding.Default,
                StandardOutputEncoding = enc ?? Encoding.Default,
                StandardErrorEncoding = enc ?? Encoding.Default
            };
            var ps = Process.Start(info);
            return ps;
        }
        public static (string output, string error) Exec(string fileName, string arg = "", string input = null, Encoding enc = null)
        {
            using var pc = Start(fileName, arg, enc: enc);
            if (input is not null) pc.StandardInput.Write(input);
            pc.WaitForExit();
            return (pc.StandardOutput.ReadToEnd(), pc.StandardError.ReadToEnd());
        }
    }
}
