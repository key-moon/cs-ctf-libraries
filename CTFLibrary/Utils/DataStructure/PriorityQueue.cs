﻿using System;
using System.Collections.Generic;
using System.Text;
using MethodImplAttribute = System.Runtime.CompilerServices.MethodImplAttribute;
using MethodImplOptions = System.Runtime.CompilerServices.MethodImplOptions;

namespace CTFLibrary
{
    public class PriorityQueue<T> where T : IComparable<T>
    {
        public int Count { get; private set; }
        private bool Descendance;
        private T[] data = new T[1 << 8];
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public PriorityQueue(bool descendance = false) { Descendance = descendance; }
        public T Top
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { ValidateNonEmpty(); return data[1]; }
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public T Pop()
        {
            var top = Top;
            var elem = data[Count--];
            int index = 1;
            while (true)
            {
                if ((index << 1) >= Count)
                {
                    if (index << 1 > Count) break;
                    if (elem.CompareTo(data[index << 1]) > 0 ^ Descendance) data[index] = data[index <<= 1];
                    else break;
                }
                else
                {
                    var nextIndex = data[index << 1].CompareTo(data[(index << 1) + 1]) <= 0 ^ Descendance ? (index << 1) : (index << 1) + 1;
                    if (elem.CompareTo(data[nextIndex]) > 0 ^ Descendance) data[index] = data[index = nextIndex];
                    else break;
                }
            }
            data[index] = elem;
            return top;
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Push(T value)
        {
            int index = ++Count;
            if (data.Length == Count) Extend(data.Length * 2);
            while ((index >> 1) != 0)
            {
                if (data[index >> 1].CompareTo(value) > 0 ^ Descendance) data[index] = data[index >>= 1];
                else break;
            }
            data[index] = value;
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private void Extend(int newSize)
        {
            T[] newDatas = new T[newSize];
            data.CopyTo(newDatas, 0);
            data = newDatas;
        }
        private void ValidateNonEmpty() { if (Count == 0) throw new Exception(); }
    }

    public class PriorityQueue<TValue, TKey> where TKey : IComparable<TKey>
    {
        public int Count { get; private set; }
        private Func<TValue, TKey> KeySelector;
        private bool Descendance;
        private TValue[] data = new TValue[1 << 8];
        private TKey[] keys = new TKey[1 << 8];
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public PriorityQueue(Func<TValue, TKey> keySelector, bool descendance = false) { KeySelector = keySelector; Descendance = descendance; }
        public TValue Top
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { ValidateNonEmpty(); return data[1]; }
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public TValue Pop()
        {
            var top = Top;
            var item = data[Count];
            var key = keys[Count--];
            int index = 1;
            while (true)
            {
                if ((index << 1) >= Count)
                {
                    if (index << 1 > Count) break;
                    if (key.CompareTo(keys[index << 1]) > 0 ^ Descendance)
                    { data[index] = data[index << 1]; keys[index] = keys[index << 1]; index <<= 1; }
                    else break;
                }
                else
                {
                    var nextIndex = keys[index << 1].CompareTo(keys[(index << 1) + 1]) <= 0 ^ Descendance ? (index << 1) : (index << 1) + 1;
                    if (key.CompareTo(keys[nextIndex]) > 0 ^ Descendance)
                    { data[index] = data[nextIndex]; keys[index] = keys[nextIndex]; index = nextIndex; }
                    else break;
                }
            }
            data[index] = item;
            keys[index] = key;
            return top;
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Push(TValue item)
        {
            var key = KeySelector(item);
            int index = ++Count;
            if (data.Length == Count) Extend(data.Length * 2);
            while ((index >> 1) != 0)
            {
                if (keys[index >> 1].CompareTo(key) > 0 ^ Descendance)
                { data[index] = data[index >> 1]; keys[index] = keys[index >> 1]; index >>= 1; }
                else break;
            }
            data[index] = item;
            keys[index] = key;
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private void Extend(int newSize)
        {
            TValue[] newData = new TValue[newSize];
            TKey[] newKeys = new TKey[newSize];
            data.CopyTo(newData, 0);
            keys.CopyTo(newKeys, 0);
            data = newData;
            keys = newKeys;
        }
        private void ValidateNonEmpty() { if (Count == 0) throw new IndexOutOfRangeException(); }
    }
}
