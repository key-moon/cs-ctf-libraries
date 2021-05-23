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
        public static Bytes ToBytes(this IEnumerable<byte> stream) => stream.ToArray().ToBytes();
        public static byte[] ToByteArray(this IEnumerable<byte> stream) => stream.ToArray();
        public static string ToString(this IEnumerable<byte> stream, Encoding encoding = null) => stream.ToArray().ToString(encoding);
        public static Bytes ToBigInteger(this IEnumerable<byte> stream, ByteOrder order = ByteOrder.Little) => stream.ToArray().ToBigInteger(order);

        // Convert between Bytes-like object and Bytes
        public static byte[] ToByteArray(this Bytes bytes) => bytes;
        public static Bytes ToBytes(this byte[] byteArray) => byteArray;

        public static string ToString(this Bytes bytes, Encoding encoding = null) => (encoding ?? MyEncoding.Raw).GetString(bytes);
        public static Bytes ToBytes(this string byteArray, Encoding encoding = null) => (encoding ?? MyEncoding.Raw).GetBytes(byteArray);

        public static BigInteger ToBigInteger(this Bytes bytes, ByteOrder order = ByteOrder.Little) => new BigInteger(bytes.AsSpan(), true, order == ByteOrder.Big);
        public static Bytes ToBytes(this BigInteger bigInt, ByteOrder order = ByteOrder.Little) => bigInt.ToByteArray(order);

        // Convert between Bytes-like objects
        public static BigInteger ToBigInteger(this byte[] byteArray, ByteOrder order = ByteOrder.Little) => new BigInteger(byteArray, isBigEndian: order == ByteOrder.Big);
        public static byte[] ToByteArray(this BigInteger bigInt, ByteOrder order = ByteOrder.Little) => bigInt.ToByteArray(true, order == ByteOrder.Big);

        public static string ToString(this byte[] bytes, Encoding encoding = null) => (encoding ?? MyEncoding.Raw).GetString(bytes);
        public static byte[] ToByteArray(this string s, Encoding encoding = null) => (encoding ?? MyEncoding.Raw).GetBytes(s);

        // Alias
        public static BigInteger Unpack(this BigInteger bigInt, ByteOrder order = ByteOrder.Little) => ToBigInteger(bigInt, order);
        public static Bytes Pack(this BigInteger bigInt, ByteOrder order = ByteOrder.Little) => ToBytes(bigInt, order);
    }
}
