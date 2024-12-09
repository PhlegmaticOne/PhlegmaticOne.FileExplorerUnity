using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;

namespace PhlegmaticOne.FileExplorer.Infrastructure.ViewModels
{
    internal sealed class ReactiveCollectionChangedEventArgs<T> : EventArgs
    {
        private readonly NotifyCollectionChangedEventArgs _collectionChangedEventArgs;

        public ReactiveCollectionChangedEventArgs(NotifyCollectionChangedEventArgs collectionChangedEventArgs)
        {
            _collectionChangedEventArgs = collectionChangedEventArgs;
        }

        public NotifyCollectionChangedAction Action => _collectionChangedEventArgs.Action;
        public IEnumerable<T> NewItems => CollectionOrDefault(_collectionChangedEventArgs.NewItems);
        public int NewStartingIndex => _collectionChangedEventArgs.NewStartingIndex;
        public IEnumerable<T> OldItems => CollectionOrDefault(_collectionChangedEventArgs.OldItems);
        public int OldStartingIndex => _collectionChangedEventArgs.OldStartingIndex;

        private static IEnumerable<T> CollectionOrDefault(IList list)
        {
            return list is null || list.Count == 0 ? Enumerable.Empty<T>() : list.OfType<T>();
        }
    }
}