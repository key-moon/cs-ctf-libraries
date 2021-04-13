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
        static readonly SHA512 sha512 = SHA512.Create();
        public static Bytes GetSHA512(this Bytes bytes) => sha512.ComputeHash(bytes);
        static readonly SHA256 sha256 = SHA256.Create();
        public static Bytes GetSHA256(this Bytes bytes) => sha256.ComputeHash(bytes);
        static readonly SHA1 sha1 = SHA1.Create();
        public static Bytes GetSHA1(this Bytes bytes) => sha1.ComputeHash(bytes);
    }
}
