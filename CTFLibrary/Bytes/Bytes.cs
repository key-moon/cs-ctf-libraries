using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace CTFLibrary
{
    public partial struct Bytes
    {
        private byte[] _data;   
        private Bytes(Span<byte> data) { _data = data.ToArray(); }
        private Bytes(byte[] data) { _data = data; }
        public byte this[int index]
        {
            get { return _data[index]; }
            set { _data = _data.ToArray(); _data[index] = value; }
        }
        public int GetBit(int i) => _data[i / 8] >> (i & 7) & 1;

        public int Length => _data.Length;

        public Bytes Slice(int begin, int length) => new Bytes(_data.AsSpan().Slice(begin, length));

        public IEnumerator GetEnumerator() => _data.GetEnumerator();
        public Span<byte> AsSpan() => _data;

        public override string ToString() => BytesConverter.ToString(this);

        public static Bytes FromSpan(Span<byte> data) => new Bytes(data);
    }
}
