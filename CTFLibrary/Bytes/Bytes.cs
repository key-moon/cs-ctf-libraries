using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace CTFLibrary
{
    public ref partial struct Bytes
    {
        private Span<byte> _data;
        private Bytes(Span<byte> data) { _data = data; }
        public byte this[int index]
        {
            get { return _data[index]; }
            set { _data[index] = value; }
        }

        public int Length => _data.Length;

        public Bytes Slice(int begin, int length) => new Bytes(_data.Slice(begin, length));

        public Span<byte>.Enumerator GetEnumerator() => _data.GetEnumerator();
        public Span<byte> AsSpan() => _data;

        public override string ToString() => BytesConverter.ToString(this);

        public static Bytes FromSpan(Span<byte> data) => new Bytes(data);
    }
}
