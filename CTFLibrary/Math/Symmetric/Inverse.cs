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
        public Symmetric Inverse()
        {
            int[] invPermute = new int[Size];
            for (int i = 0; i < Permute.Length; i++) invPermute[Permute[i]] = i;
            return new Symmetric(invPermute);
        }
    }
}

