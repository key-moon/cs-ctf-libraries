using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

using System.Runtime.Intrinsics.X86;

namespace CTFLibrary
{
    public static partial class MyMath
    {
        // * Copyright 2019 Bradley Berg   < (My last name) @ t e c h n e o n . c o m >
        // *
        // * Permission to use, copy, modify, and distribute this software for any
        // * purpose with or without fee is hereby granted, provided that the above
        // * copyright notice and this permission notice appear in all copies.
        //
        // https://www.techneon.com/download/is.prime.32.base.data
        static uint[] IntBaseTable = new uint[256] { 1216, 1836, 8885, 4564, 10978, 5228, 15613, 13941, 1553, 173, 3615, 3144, 10065, 9259, 233, 2362, 6244, 6431, 10863, 5920, 6408, 6841, 22124, 2290, 45597, 6935, 4835, 7652, 1051, 445, 5807, 842, 1534, 22140, 1282, 1733, 347, 6311, 14081, 11157, 186, 703, 9862, 15490, 1720, 17816, 10433, 49185, 2535, 9158, 2143, 2840, 664, 29074, 24924, 1035, 41482, 1065, 10189, 8417, 130, 4551, 5159, 48886, 786, 1938, 1013, 2139, 7171, 2143, 16873, 188, 5555, 42007, 1045, 3891, 2853, 23642, 148, 3585, 3027, 280, 3101, 9918, 6452, 2716, 855, 990, 1925, 13557, 1063, 6916, 4965, 4380, 587, 3214, 1808, 1036, 6356, 8191, 6783, 14424, 6929, 1002, 840, 422, 44215, 7753, 5799, 3415, 231, 2013, 8895, 2081, 883, 3855, 5577, 876, 3574, 1925, 1192, 865, 7376, 12254, 5952, 2516, 20463, 186, 5411, 35353, 50898, 1084, 2127, 4305, 115, 7821, 1265, 16169, 1705, 1857, 24938, 220, 3650, 1057, 482, 1690, 2718, 4309, 7496, 1515, 7972, 3763, 10954, 2817, 3430, 1423, 714, 6734, 328, 2581, 2580, 10047, 2797, 155, 5951, 3817, 54850, 2173, 1318, 246, 1807, 2958, 2697, 337, 4871, 2439, 736, 37112, 1226, 527, 7531, 5418, 7242, 2421, 16135, 7015, 8432, 2605, 5638, 5161, 11515, 14949, 748, 5003, 9048, 4679, 1915, 7652, 9657, 660, 3054, 15469, 2910, 775, 14106, 1749, 136, 2673, 61814, 5633, 1244, 2567, 4989, 1637, 1273, 11423, 7974, 7509, 6061, 531, 6608, 1088, 1627, 160, 6416, 11350, 921, 306, 18117, 1238, 463, 1722, 996, 3866, 6576, 6055, 130, 24080, 7331, 3922, 8632, 2706, 24108, 32374, 4237, 15302, 287, 2296, 1220, 20922, 3350, 2089, 562, 11745, 163, 11951 };
        public static bool IsPrime(this int value) => value < 0 ? throw new Exception() : IsPrime((uint)value);
        public static bool IsPrime(this uint value)
        {
            if (value == 2) return true; 
            if (value == 1 || ((value & 1) == 0)) return false;
            var b = IntBaseTable[(0xad625b89U * value) >> 24];
            var d = value - 1;
            while ((d & 1) == 0) d >>= 1;
            static ulong Power(ulong n, long m, uint mod)
            {
                ulong pow = n;
                ulong res = 1;
                while (m > 0)
                {
                    if ((m & 1) == 1)
                    {
                        res *= pow;
                        res %= mod;
                    }
                    pow *= pow;
                    pow %= mod;
                    m >>= 1;
                }
                return res;
            }
            var cur = Power(b, d, value);
            if (cur == 1) return true;
            do
            {
                if (cur == value - 1) return true;
                cur *= cur;
                cur %= value;
                d <<= 1;
            } while (d < value);
            return false;
        }
        public static bool IsPrime(this BigInteger value)
        {
            if (value < 0) throw new Exception();
            if (value == 2) return true;
            if (value == 1 || ((value & 1) == 0)) return false;
            if (value == 2) return true;
            if (value == 1 || ((value & 1) == 0)) return false;
            Random rng = new Random();
            const int CNT = 20;
            for (int cnt = 0; cnt < CNT; cnt++)
            {
                BigInteger b = 0;
                while (b < value)
                {
                    b *= int.MaxValue;
                    b += rng.Next();
                }
                b %= value - 1;
                b++;
                var d = value - 1;
                while ((d & 1) == 0) d >>= 1;
                var cur = BigInteger.ModPow(b, d, value);
                if (cur == 1) goto valid;
                do
                {
                    if (cur == value - 1) goto valid;
                    cur *= cur;
                    cur %= value;
                    d <<= 1;
                } while (d < value);
                return false;
                valid:;
            }
            return true;
        }
    }
}

