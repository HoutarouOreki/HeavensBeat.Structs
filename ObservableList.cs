using System;
using System.Collections;
using System.Collections.Generic;

namespace HeavensBeat.Structs
{
    public class ObservableList<T> : ICollection<T>, IList<T>
    {
        private readonly List<T> list;

        public ObservableList() => list = new List<T>();
        public ObservableList(IEnumerable<T> collection) => list = new List<T>(collection);

        public event Action<T>? ItemAdded;
        public event Action<T>? ItemRemoved;

        public T this[int index] { get => list[index]; set => list[index] = value; }

        public int Count => list.Count;

        public bool IsReadOnly => false;

        public void Add(T item)
        {
            list.Add(item);
            ItemAdded?.Invoke(item);
        }

        public void AddRange(IEnumerable<T> collection)
        {
            foreach (var item in collection)
                Add(item);
        }

        public void Clear()
        {
            var items = new List<T>(list);
            list.Clear();
            foreach (var item in items)
                ItemRemoved?.Invoke(item);
        }

        public bool Contains(T item) => list.Contains(item);
        public void CopyTo(T[] array, int arrayIndex) => list.CopyTo(array, arrayIndex);
        public IEnumerator<T> GetEnumerator() => ((ICollection<T>)list).GetEnumerator();
        public int IndexOf(T item) => list.IndexOf(item);

        public void Insert(int index, T item)
        {
            list.Insert(index, item);
            ItemAdded?.Invoke(item);
        }

        public bool Remove(T item)
        {
            var result = list.Remove(item);
            ItemRemoved?.Invoke(item);
            return result;
        }

        public void RemoveAt(int index)
        {
            var item = list[index];
            list.RemoveAt(index);
            ItemRemoved?.Invoke(item);
        }

        IEnumerator IEnumerable.GetEnumerator() => list.GetEnumerator();
    }
}
