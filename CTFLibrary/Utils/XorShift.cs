using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace CTFLibrary
{
    [StructLayout(LayoutKind.Explicit)]
    public class XorShift
    {
        [FieldOffset(0)]
        private byte __byte;
        [FieldOffset(0)]
        private sbyte __sbyte;
        [FieldOffset(0)]
        private char __char;
        [FieldOffset(0)]
        private short __short;
        [FieldOffset(0)]
        private ushort __ushort;
        [FieldOffset(0)]
        private int __int;
        [FieldOffset(0)]
        private uint __uint;
        [FieldOffset(0)]
        private long __long;
        [FieldOffset(0)]
        private ulong __ulong;

        public byte Byte { get { Update(); return __byte; } }
        public sbyte SByte { get { Update(); return __sbyte; } }
        public char Char { get { Update(); return __char; } }
        public short Short { get { Update(); return __short; } }
        public ushort UShort { get { Update(); return __ushort; } }
        public int Int { get { Update(); return __int; } }
        public uint UInt { get { Update(); return __uint; } }
        public long Long { get { Update(); return __long; } }
        public ulong ULong { get { Update(); return __ulong; } }
        public double Double { get { return (double)ULong / ulong.MaxValue; } }

        [FieldOffset(0)]
        private ulong _xorshift;

        public XorShift() : this(0) { }
        public XorShift(ulong seed) { SetSeed(seed); }
        public void SetSeed(ulong seed) => _xorshift = (seed == 0 ? (ulong)DateTime.Now.Ticks : seed) * 0x3141592c0ffeeul;

        public int Next() => Int & 2147483647;
        public void Update()
        {
            _xorshift ^= _xorshift << 7;
            _xorshift ^= _xorshift >> 9;
        }
    }
}
