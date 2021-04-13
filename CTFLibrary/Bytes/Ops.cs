using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using System.Numerics;

namespace CTFLibrary
{
    public ref partial struct Bytes
    {
        public static bool operator ==(Bytes a, Bytes b) => a._data == b._data;
        public static bool operator !=(Bytes a, Bytes b) => a._data != b._data;

        public static implicit operator byte[](Bytes bytes) => bytes._data.ToArray();
        public static implicit operator Bytes(byte[] byteArray) => new Bytes(byteArray);

        public static implicit operator string(Bytes bytes) => bytes.ToString();
        public static implicit operator Bytes(string str) => str.ToBytes();

        public static implicit operator BigInteger(Bytes bytes) => bytes.ToBigInteger();
        public static implicit operator Bytes(BigInteger bigInt) => bigInt.ToBytes();
    }
}
