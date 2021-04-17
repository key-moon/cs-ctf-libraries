using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CTFLibrary
{
    public partial class Symmetric
    {
        public static Symmetric Identity(int n) => new Symmetric(Enumerable.Range(0, n).ToArray());
        public static Symmetric Reverse(int n) => new Symmetric(Enumerable.Range(0, n).Reverse().ToArray());
        public static Symmetric RotateLeft(int n, int i) => new Symmetric(Enumerable.Range(0, n).Reverse().RotateRight(i).ToArray());
        public static Symmetric RotateRight(int n, int i) => new Symmetric(Enumerable.Range(0, n).Reverse().RotateLeft(i).ToArray());
    }
}

