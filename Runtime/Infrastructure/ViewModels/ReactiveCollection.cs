using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;

namespace PhlegmaticOne.FileExplorer.Infrastructure.ViewModels
{
    internal sealed class ReactiveCollection<T> : ICollection<T>
    {
        private readonly ObservableCollection<T> _collection;
        
        public ReactiveCollection()
        {
            _collection = new ObservableCollection<T>();
            _collection.CollectionChanged += OnPrivateCollectionChanged;
        }

        public event Action<ReactiveCollectionChangedEventArgs<T>> CollectionChanged;

        public int Count => _collection.Count;

        public bool IsReadOnly => false;

        public void Add(T item)
        {
            _collection.Add(item);
        }

        public void Clear()
        {
            _collection.Clear();
        }

        public bool Contains(T item)
        {
            return _collection.Contains(item);
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            _collection.CopyTo(array, arrayIndex);
        }

        public bool Remove(T item)
        {
            return _collection.Remove(item);
        }

        public IEnumerator<T> GetEnumerator()
        {
            return _collection.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable)_collection).GetEnumerator();
        }

        private void OnPrivateCollectionChanged(object _, NotifyCollectionChangedEventArgs eventArgs)
        {
            CollectionChanged?.Invoke(new ReactiveCollectionChangedEventArgs<T>(eventArgs));
        }
    }
}