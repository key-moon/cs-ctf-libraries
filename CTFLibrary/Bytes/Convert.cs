using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using System.Numerics;

namespace CTFLibrary
{
    public static class BytesConverter
    {
        public static byte[] ToByteArray(this Bytes bytes) => bytes;
        public static Bytes ToBytes(this byte[] byteArray) => byteArray;

        public static string ToString(this Bytes bytes, Encoding encoding = null) => (encoding ?? Encoding.ASCII).GetString(bytes);
        public static Bytes ToBytes(this string byteArray, Encoding encoding = null) => (encoding ?? Encoding.ASCII).GetBytes(byteArray);

        public static BigInteger ToBigInteger(this Bytes bytes, ByteOrder order = ByteOrder.Little) => new BigInteger(bytes.AsSpan(), false, order == ByteOrder.Big);
        public static Bytes ToBytes(this BigInteger bigInt, ByteOrder order = ByteOrder.Little) => bigInt.ToByteArray(false, order == ByteOrder.Big);

        public static BigInteger Unpack(this BigInteger bigInt, ByteOrder order = ByteOrder.Little) => ToBigInteger(bigInt, order);
        public static Bytes Pack(this BigInteger bigInt, ByteOrder order = ByteOrder.Little) => ToBytes(bigInt, order);
    }
}
