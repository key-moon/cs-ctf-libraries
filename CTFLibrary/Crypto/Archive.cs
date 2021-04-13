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
    class Archive
    {
        public static bool TryUnZip(string path, string savePath, string password)
        {
            FastZip fastZip = new FastZip { Password = password };
            var filename = Path.GetFileNameWithoutExtension(path);
            try
            {
                fastZip.ExtractZip(path, $"{savePath}/{filename}", "");
            }
            catch
            {
                Directory.Delete($"{savePath}/{filename}", true);
                return false;
            }
            return true;
        }
    }
}
