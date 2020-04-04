using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace HeavensBeat.Structs
{
    public class ReadOnlyObservableList<T> : IReadOnlyList<T>
    {
        private readonly ObservableList<T> list;

        public ReadOnlyObservableList(ObservableList<T> collection) => list = collection;

        public void SubscribeToItemAdded(Action<T> action) => list.ItemAdded += action;
        public void SubscribeToItemRemoved(Action<T> action) => list.ItemRemoved += action;

        public void UnsubscribeFromItemAdded(Action<T> action) => list.ItemAdded -= action;
        public void UnsubscribeFromItemRemoved(Action<T> action) => list.ItemRemoved -= action;

        public T this[int index] => list[index];

        public int Count => list.Count;

        public IEnumerator<T> GetEnumerator() => list.GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => list.GetEnumerator();

        public static implicit operator ReadOnlyObservableList<T>(ObservableList<T> list) => new ReadOnlyObservableList<T>(list);
    }
}
