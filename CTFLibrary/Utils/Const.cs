using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace CTFLibrary
{
    public static class Const
    {
        public const string Digits = "0123456789";
        public const string LowercaseLetters = "abcdefghijklmnopqrstuvwxyz";
        public const string UppercaseLetters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        public const string PrintableLetters = " !\"#$%&'()*+,-./0123456789:;<=>?@ABCDEFGHIJKLMNOPQRSTUVWXYZ[\\]^_`abcdefghijklmnopqrstuvwxyz{|}~";
        public const string HexLetters = Digits + "abcdefABCDEF";
        public const string Base64Letters = UppercaseLetters + LowercaseLetters + Digits + "+/=";
    }
}
