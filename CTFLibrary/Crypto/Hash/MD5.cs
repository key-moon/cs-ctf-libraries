using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace CTFLibrary.Crypto
{
    static partial class Hash
    {
        static MD5 md5 = MD5.Create();
        public static Bytes GetMD5(this Bytes bytes) => md5.ComputeHash(bytes);
    }
}
