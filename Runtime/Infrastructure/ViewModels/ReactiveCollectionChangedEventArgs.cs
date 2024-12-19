using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;

namespace PhlegmaticOne.FileExplorer.Infrastructure.ViewModels
{
    internal sealed class ReactiveCollectionChangedEventArgs<T> : EventArgs
    {
        public static ReactiveCollectionChangedEventArgs<T> Reset()
        {
            return new ReactiveCollectionChangedEventArgs<T>(NotifyCollectionChangedAction.Reset, ArraySegment<T>.Empty);
        }
        
        public static ReactiveCollectionChangedEventArgs<T> Added(T item)
        {
            return new ReactiveCollectionChangedEventArgs<T>(NotifyCollectionChangedAction.Add, new [] { item });
        }
        
        public static ReactiveCollectionChangedEventArgs<T> Added(IReadOnlyCollection<T> addedItems)
        {
            return new ReactiveCollectionChangedEventArgs<T>(NotifyCollectionChangedAction.Add, addedItems);
        }

        public static ReactiveCollectionChangedEventArgs<T> Removed(T item)
        {
            return new ReactiveCollectionChangedEventArgs<T>(NotifyCollectionChangedAction.Remove, new [] { item });
        }
        
        public static ReactiveCollectionChangedEventArgs<T> Removed(IReadOnlyCollection<T> removedItems)
        {
            return new ReactiveCollectionChangedEventArgs<T>(NotifyCollectionChangedAction.Remove, removedItems);
        }

        private ReactiveCollectionChangedEventArgs(NotifyCollectionChangedAction action, IReadOnlyCollection<T> affectedItems)
        {
            Action = action;
            AffectedItems = affectedItems;
        }

        public NotifyCollectionChangedAction Action { get; }
        public IReadOnlyCollection<T> AffectedItems { get; }
    }
}