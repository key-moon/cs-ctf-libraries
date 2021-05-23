using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CTFLibrary
{
    public static class Git
    {
        public static (string content, string hash, ObjectType type)[] Dump(string path, ObjectType show = ObjectType.All, bool doStdOut = true)
        {
            var cwd = Environment.CurrentDirectory;
            try
            {
                Directory.SetCurrentDirectory(path);
                var (output1, err1) = ProcessUtil.Exec("git", "cat-file --batch-all-objects --buffer --batch-check");
                var hashes = output1.Trim().Split('\n').Select(x =>
                {
                    var splitted = x.Split();
                    return (hash: splitted[0], type: splitted[1] switch { 
                        "blob" => ObjectType.Blob,
                        "tree" => ObjectType.Tree,
                        "commit" => ObjectType.Commit,
                        "tag" => ObjectType.Tag,
                        _ => ObjectType.None
                    });
                }).Where(x => (show & x.type) != ObjectType.None).ToArray();

                var hashesStr = hashes.Select(x => x.hash).Join('\n');

                Task<(string content, string hash, ObjectType type)>[] tasks = 
                    hashes.Select(x => Task.Run<(string, string, ObjectType)>(() =>
                    {
                        var (output, err) = ProcessUtil.Exec("git", $"cat-file -p {x.hash}", enc: Encoding.UTF8);
                        if (doStdOut) Console.WriteLine($"\n==== BEGIN {x.hash}: {x.type} ====\n{output.ToPrintable('?')}\n====   END {x.hash}: {x.type} ====");
                        return (output, x.hash, x.type);
                    })).ToArray();
                Task.WaitAll(tasks);
                return tasks.Select(x => x.Result).ToArray();
            }
            finally
            {
                Directory.SetCurrentDirectory(cwd);
            }
        }
        [Flags]
        public enum ObjectType
        {
            None,
            Blob = 1,
            Tree = 2,
            Commit = 4,
            Tag = 8,
            All = Blob | Tree | Commit | Tag
        }
    }
}
