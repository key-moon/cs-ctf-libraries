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
        int Size => Permute.Length;
        readonly int[] Permute;
        private Symmetric(int[] permute) { Permute = permute; }

        public int this[int index] => Permute[index];

        public static Symmetric Create(int[] permute)
        {
            bool[] hasValue = new bool[permute.Length];
            for (int i = 0; i < permute.Length; i++)
            {
                if (permute[i] < 0 || hasValue.Length <= permute[i] || hasValue[permute[i]])
                    throw new ArgumentException("argument is not not permutation", nameof(permute));
                hasValue[permute[i]] = true;
            }
            return new Symmetric(permute);
        }

        public int[] ToArray() => Permute.ToArray();
        public override string ToString() => $"{{ {string.Join(", ", Permute.Select((elem, ind) => $"{ind}=>{elem}"))} }}";
    }
}

