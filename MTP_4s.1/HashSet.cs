﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace MTP_4s._1
{
    public class HashSet<T> : ISet<T>
    {
        private List<T>[] items;
        private const int Capacity = 10 ;
        public int DinamicCapacity { get; private set; } = 10;
        public HashSet()
        {
            items = new List<T>[Capacity];
        }
        public int Count { get; private set; } = 0;
        public bool isEmpty
        {
            get
            {
                if (Count == 0)
                    return false;
                else
                    return true;
            }
        }

        public void Add(T value)
        {
            if (value == null)
                throw new ArgumentNullException();
            if (items == null)
                items = new List<T>[Capacity];
            var key = GetHash(value);
            if(key >= items.Length)
                AppendCapacity(key);
            if (items[key] == null)
            {
                items[key] = new List<T>() { value };
                Count++;
            }
            else
            {
                if (!items[key].Contains(value))
                {
                    items[key].Add(value);
                    Count++;
                }
                else
                    return;
            }
        }
        public void Clear()
        {
            Count = 0;
            DinamicCapacity = 10;
            items = new List<T>[Capacity];
        }
        public bool Contains(T value)
        {
            if (value == null)
                throw new ArgumentNullException();
            if (Count == 0)
                return false;
            var key = GetHash(value);
            if (key > items.Length)
                return false;
            if (items[key] == null)
                return false;
            else
                return items[key].Contains(value);
        }

        private int GetHash(T value)
        {
            int key = 0;
            int v = Math.Abs(value.GetHashCode());
            while(v > 0)
            {
                key += v % 10;
                v /= 10;
            }
            /*for (int i = 0; i < value.ToString().Length; i++)
                key += Convert.ToInt32(value.GetHashCode().ToString()[i]);*/
            return key;
            //return Convert.ToInt32(value.GetHashCode().ToString()[0]) * Convert.ToInt32(value.GetHashCode().ToString()[5]);
            //return value.ToString().Length % 2 == 0 ? value.ToString().Length * 2 : value.ToString().Length * 2 - 1;
        }

        public void Remove(T value)
        {
            if (value == null)
                throw new ArgumentNullException();
            if (items == null)
                return;
            var key = GetHash(value);
            if (items[key] != null)
            {
                if(items[key].Contains(value) == true)
                {
                    items[key].Remove(value);
                    Count--;
                }
            }
        }
        private void AppendCapacity(int c)
        {           
            var tempitems = items;
            while (c >= DinamicCapacity)
            {
                DinamicCapacity += 10;
            }           
            items = new List<T>[DinamicCapacity];
            Array.Copy(tempitems, items, tempitems.Length);
        }

        public HashSet<T> Union(HashSet<T> set)
        {
            HashSet<T> result = new HashSet<T>();
            for (int i = 0; i < set.items.Length; i++)
            {
                if (set.items[i] != null)
                    foreach (var item in set.items[i])
                        result.Add(item);
            }
            for(int i = 0; i < items.Length;i++)
            {
                if (items[i] != null)
                    foreach (var item in items[i])
                        result.Add(item);
            }
            return result;
        }
        public HashSet<T> Intersection(HashSet<T> set)
        {
            HashSet<T> result = new HashSet<T>();
            for(int i = 0;i < items.Length;i++)
            {
                if (items[i] != null)
                {
                    foreach(var item in items[i])
                        if(set.Contains(item) == true)
                        {
                            result.Add(item);
                        }
                }
            }
            return result;
        }
        public HashSet<T> Difference(HashSet<T> set)
        {
            HashSet<T> result = new HashSet<T>();
            for(int i = 0;i < items.Length;i++)
            {
                if (items[i] != null)
                    foreach (var item in items[i])
                        if (set.Contains(item) == false)
                            result.Add(item);
            }
            return result;
        }
        public bool Subset(HashSet<T> set)
        {
            for(int i = 0; i < items.Length ; i++)
            {
                if (items[i] != null)
                    foreach (var item in items[i])
                        if (set.Contains(item))
                            return true;
            }
            return false;
        }
        public HashSet<T> SymmetricDifference(HashSet<T> set)
        {
            HashSet<T> result = new HashSet<T>();
            for (int i = 0; i < set.items.Length; i++)
            {
                if (set.items[i] != null)
                    foreach (var item in set.items[i])
                        result.Add(item);
            }
            for (int i = 0; i < items.Length; i++)
            {
                if (items[i] != null)
                    foreach (var item in items[i])
                    {
                        if (set.Contains(item) == true)
                            result.Remove(item);
                        else
                            result.Add(item);
                    }
            }
            return result;
        }

        public IEnumerator<T> GetEnumerator()
        {
            return new HashSetEnumerator(items);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return new HashSetEnumerator(items);
        }

        private class HashSetEnumerator : IEnumerator<T>
        {
            List<T>[] items;
            int position_1;
            int position_2;
            public HashSetEnumerator(List<T>[] items)
            {
                this.items = items;
                position_1 = -1;
                position_2 = -1;
            }
            public object Current
            {
                get
                {
                    if (position_1 == -1 || position_2 == -1 || position_1 >= items.Length)
                        throw new InvalidOperationException();
                    return items[position_1][position_2];
                }
            }
            T IEnumerator<T>.Current
            {
                get
                {
                    if (position_1 == -1 || position_2 == -1 || position_1 >= items.Length)
                        throw new InvalidOperationException();
                    return items[position_1][position_2];
                }
            }
            public void Dispose()
            { }

            public bool MoveNext()
            {
                if (position_1 == -1)
                    position_1++;
                if (items[position_1] != null)
                {
                    if (position_2 >= items[position_1].Count - 1)
                    {
                        position_1++;
                        position_2 = -1;
                    }
                }
                while (items[position_1] == null && position_1 < items.Length - 1)
                {
                    position_1++;
                }
                if (position_1 < items.Length - 1)
                {                   
                    position_2++;
                    return true;
                }
                else
                    return false;
            }

            public void Reset()
            {
                position_1 = -1;
                position_2 = -1;
            }
        }
    }
}
