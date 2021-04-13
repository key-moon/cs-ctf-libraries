using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace CTFLibrary
{
    static class Radix
    {
        public static BigInteger ParseToBigInteger(this string s) => BigInteger.Parse(s);
        public static BigInteger ParseFromBaseK(
            this string s,
            int k,
            string digits = Const.Digits + Const.LowercaseLetters + Const.UppercaseLetters
        )
        {
            int[] digitMap = new int[256];
            Array.Fill(digitMap, -1);
            for (int i = 0; i < digits.Length; i++)
            {
                if (digitMap[digits[i]] != -1) throw new ArgumentException($"duplicated character {digits[i]}", nameof(digits));
                digitMap[digits[i]] = i;
            }
            BigInteger res = 0;
            foreach (var c in s)
            {
                res *= k;
                if (digitMap[c] == -1) throw new ArgumentException($"invalid character {c}", nameof(s));
                res += digitMap[c];
            }
            return res;
        }
        public static string ToBaseKString(this BigInteger bigInt, int k, string digits = Const.Digits + Const.LowercaseLetters + Const.UppercaseLetters)
        {
            List<char> chars = new List<char>();
            while (bigInt != 0)
            {
                bigInt = BigInteger.DivRem(bigInt, k, out BigInteger rem);
                chars.Add(digits[(int)rem]);
            }
            chars.Reverse();
            return string.Join("", chars);
        }

        public static Bytes DecodeFromBase64(this string s) => Convert.FromBase64String(s);
        public static string EncodeToBase64(this Bytes s) => Convert.ToBase64String(s);
    }
}
