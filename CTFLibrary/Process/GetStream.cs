using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime;
using System.Diagnostics;
using System.IO;

namespace CTFLibrary
{
    public static partial class ProcessUtil
    {
        public static Stream GetStream(this Process ps)
        {
            return new MergedStream(ps.StandardOutput.BaseStream, ps.StandardInput.BaseStream);
        }
    }
}
