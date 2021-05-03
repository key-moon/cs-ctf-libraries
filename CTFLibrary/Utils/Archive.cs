using ICSharpCode.SharpZipLib;
using ICSharpCode.SharpZipLib.Zip;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CTFLibrary
{
    public static class Archive
    {
        public static string TryUnZip(string path, string password, string fileName = null)
        {
            FastZip fastZip = new FastZip { Password = password };
            fileName ??= $"{Path.GetFileNameWithoutExtension(path)}_res";
            var savePath = Path.Combine(Directory.GetParent(path).FullName, fileName);
            try
            {
                fastZip.ExtractZip(path, savePath, "");
            }
            catch
            {
                Directory.Delete(savePath, true);
                return null;
            }
            return savePath;
        }
    }
}
