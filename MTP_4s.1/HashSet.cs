using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace MTP_4s._1
{
    public class HashSet<T> : ISet<T>
    {
        private List<T>[] items;
        private int cnt = 0;
        public int Capacity { get; private set; }
        public HashSet()
        {
            Capacity = 10;
            items = new List<T>[Capacity];
        }
        public int Count => this.cnt;

        public bool isEmpty
        {
            get
            {
                if (cnt == 0)
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
            if(key >= Capacity)
                AppendCapacity(key);
            if (items[key] == null)
            {
                items[key] = new List<T>() { value };
                cnt++;
            }
            else
            {
                if (!items[key].Contains(value))
                {
                    items[key].Add(value);
                    cnt++;
                }
                else
                    return;
            }
        }
        public void Clear()
        {
            cnt = 0;
            Capacity = 10;
            items = null;
        }
        public bool Contains(T value)
        {
            if (value == null)
                throw new ArgumentNullException();
            if (cnt == 0)
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
                    cnt--;
                }
            }
        }
        private void AppendCapacity(int c)
        {
            var tempitems = this.items;
            while (c >= Capacity)
            {
                Capacity += 10;
            }
            this.items = new List<T>[Capacity];
            for (int i = 0; i < tempitems.Length; i++)
            {
                if(tempitems[i] != null)
                    items[i] = new List<T>(tempitems[i]);
            }
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
            for (int i = 0; i < items.Length; i++)
            {
                if (items[i] != null)
                    foreach (var item in items[i])
                        yield return item;
            }
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
