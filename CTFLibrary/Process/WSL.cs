using System;
using System.IO;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Runtime;
using System.Diagnostics;

namespace CTFLibrary
{
    public static partial class ProcessUtil
    {
        public static string GetWSLPath(string path)
        {
            if (!Path.IsPathRooted(path)) return path.Replace('\\', '/');
            var fullPath = Path.GetFullPath(path);
            var root = Path.GetPathRoot(fullPath);
            if (Regex.IsMatch(root, @"^[A-Za-z]:[/\\]")) return $"/mnt/{char.ToLower(root[0])}/{fullPath[root.Length..].Replace('\\', '/')}";
            return path;
        }
        public static Process StartOnWSL(
            string fileName,
            string arg = null,
            string workingDirectory = null,
            bool redirectStandardInput = true,
            bool redirectStandardOutput = true,
            bool redirectStandardError = true,
            Encoding enc = null
        )
        {
            return Start(
                "wsl",
                $"-- {GetWSLPath(fileName)} {arg}",
                workingDirectory,
                redirectStandardInput,
                redirectStandardOutput,
                redirectStandardError,
                enc
            );
        }
        public static (string output, string error) ExecOnWSL(string fileName, string arg = "", string input = null, Encoding enc = null)
        {
            using var pc = StartOnWSL(fileName, arg, enc: enc);
            if (input is not null) pc.StandardInput.Write(input);
            pc.WaitForExit();
            return (pc.StandardOutput.ReadToEnd(), pc.StandardError.ReadToEnd());
        }
    }
}
