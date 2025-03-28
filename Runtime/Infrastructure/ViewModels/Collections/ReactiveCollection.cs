﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace PhlegmaticOne.FileExplorer.Infrastructure.ViewModels
{
    internal sealed class ReactiveCollection<T> : ICollection<T>
    {
        private readonly List<T> _collection = new();
        
        public event Action<ReactiveCollectionChangedEventArgs<T>> CollectionChanged;

        public T this[int index] => _collection[index];
        
        public int Count => _collection.Count;

        public bool IsReadOnly => false;

        public ReactiveCollection() { }

        public ReactiveCollection(IEnumerable<T> items)
        {
            _collection.AddRange(items);
        }

        public int IndexOf(T item)
        {
            return _collection.IndexOf(item);
        }

        public void Add(T item)
        {
            _collection.Add(item);
            OnCollectionChanged(ReactiveCollectionChangedEventArgs<T>.Added(item));
        }

        public void AddRange(IEnumerable<T> items)
        {
            var enumerated = items.ToArray();
            
            foreach (var action in enumerated)
            {
                _collection.Add(action);
            }
            
            OnCollectionChanged(ReactiveCollectionChangedEventArgs<T>.Added(enumerated));
        }

        public void Clear()
        {
            _collection.Clear();
            OnCollectionChanged(ReactiveCollectionChangedEventArgs<T>.Reset());
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
            var isRemoved = _collection.Remove(item);

            if (isRemoved)
            {
                OnCollectionChanged(ReactiveCollectionChangedEventArgs<T>.Removed(item));
            }

            return isRemoved;
        }

        public void RemoveRangeFromLast(int count)
        {
            var start = _collection.Count - 1;
            var end = start - count;
            var removedItems = new List<T>();
            
            for (var i = start; i > end; i--)
            {
                removedItems.Add(_collection[i]);
                _collection.RemoveAt(i);
            }
            
            OnCollectionChanged(ReactiveCollectionChangedEventArgs<T>.Removed(removedItems));
        }
        
        public void RemoveRange(IEnumerable<T> items)
        {
            var removed = new List<T>();
            
            foreach (var item in items)
            {
                if (_collection.Remove(item))
                {
                    removed.Add(item);
                }
            }

            OnCollectionChanged(ReactiveCollectionChangedEventArgs<T>.Removed(removed));
        }

        public IEnumerator<T> GetEnumerator()
        {
            return _collection.GetEnumerator();
        }

        public override string ToString()
        {
            return _collection.ToString();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable)_collection).GetEnumerator();
        }

        private void OnCollectionChanged(ReactiveCollectionChangedEventArgs<T> eventArgs)
        {
            CollectionChanged?.Invoke(eventArgs);
        }
    }
}