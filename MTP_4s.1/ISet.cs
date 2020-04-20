using System;
using System.Collections;
using System.Collections.Generic;

namespace MTP_4s._1
{
    public interface ISet<T> : IEnumerable<T>
    {
        void Add(T value);
        void Clear();
        bool Contains(T value);
        void Remove(T value);
        int Count { get; }
        bool isEmpty { get; }
    }
}