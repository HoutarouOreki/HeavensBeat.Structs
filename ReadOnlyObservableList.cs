using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace HeavensBeat.Structs
{
    public class ReadOnlyObservableList<T> : IReadOnlyList<T>
    {
        private readonly ObservableList<T> list;

        public ReadOnlyObservableList(IEnumerable<T> collection)
        {
            list = new ObservableList<T>(collection);
            list.ItemAdded += ItemAdded;
            list.ItemRemoved += ItemRemoved;
        }

        public event Action<T>? ItemAdded;
        public event Action<T>? ItemRemoved;

        public T this[int index] => list[index];

        public int Count => list.Count;

        public IEnumerator<T> GetEnumerator() => list.GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => list.GetEnumerator();

        public static implicit operator ReadOnlyObservableList<T>(ObservableList<T> list) => new ReadOnlyObservableList<T>(list);

        public static implicit operator ReadOnlyObservableList<T>(List<T> list) => new ReadOnlyObservableList<T>(list);
    }
}
