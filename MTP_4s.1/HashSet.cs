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
        private int Capacity { get; set; }
        public HashSet()
        {
            Capacity = 25;
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
            var key = GetHash(value);
            while(key > Capacity)
                AppendCapacity();
            if (items[key] == null)
            {
                items[key] = new List<T>() { value };
                cnt++;
            }
            else
            {
                if (items[key].Contains(value) != true)
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
            items = null;
        }
        public bool Contains(T value)
        {
            if (cnt == 0)
                return false;
            var key = GetHash(value);
            if (items[key] == null)
                return false;
            else
                return items[key].Contains(value);
        }

        private int GetHash(T value)
        {      
            return value.GetHashCode() % items.Length;
        }

        public void Remove(T value)
        {
            var key = GetHash(value);
            if (items[key] != null)
            {
                items[key].Remove(value);
                cnt--;
            }
        }
        private void AppendCapacity()
        {
            var tempitems = this.items;
            Capacity *= 2;
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
            /*for(int i = 0;i<items.Length;i++)
            {
                yield return this[i];
            }*/
            //return items.GetEnumerator();
            throw new NotImplementedException();
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
            //throw new NotImplementedException();
        }
    }
}
