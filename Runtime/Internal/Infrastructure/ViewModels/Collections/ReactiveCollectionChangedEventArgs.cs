using System;
using System.Collections.Generic;

namespace PhlegmaticOne.FileExplorer.Infrastructure.ViewModels
{
    internal sealed class ReactiveCollectionChangedEventArgs<T> : EventArgs
    {
        public static ReactiveCollectionChangedEventArgs<T> Reset()
        {
            return new ReactiveCollectionChangedEventArgs<T>(ReactiveCollectionChangedAction.Reset, ArraySegment<T>.Empty);
        }
        
        public static ReactiveCollectionChangedEventArgs<T> Added(T item)
        {
            return new ReactiveCollectionChangedEventArgs<T>(ReactiveCollectionChangedAction.Add, new [] { item });
        }
        
        public static ReactiveCollectionChangedEventArgs<T> Added(IReadOnlyCollection<T> addedItems)
        {
            return new ReactiveCollectionChangedEventArgs<T>(ReactiveCollectionChangedAction.Add, addedItems);
        }

        public static ReactiveCollectionChangedEventArgs<T> Removed(T item)
        {
            return new ReactiveCollectionChangedEventArgs<T>(ReactiveCollectionChangedAction.Remove, new [] { item });
        }
        
        public static ReactiveCollectionChangedEventArgs<T> Removed(IReadOnlyCollection<T> removedItems)
        {
            return new ReactiveCollectionChangedEventArgs<T>(ReactiveCollectionChangedAction.Remove, removedItems);
        }

        private ReactiveCollectionChangedEventArgs(ReactiveCollectionChangedAction action, IReadOnlyCollection<T> affectedItems)
        {
            Action = action;
            AffectedItems = affectedItems;
        }

        public ReactiveCollectionChangedAction Action { get; }
        public IReadOnlyCollection<T> AffectedItems { get; }
    }
}