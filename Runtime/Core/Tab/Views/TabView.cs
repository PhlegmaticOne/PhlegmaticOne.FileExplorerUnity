using System.Collections.Specialized;
using PhlegmaticOne.FileExplorer.Core.FileEntries.ViewModels;
using PhlegmaticOne.FileExplorer.Core.Tab.ViewModels;
using PhlegmaticOne.FileExplorer.Infrastructure.ViewModels;
using UnityEngine;

namespace PhlegmaticOne.FileExplorer.Core.Tab.Views
{
    internal sealed class TabView : MonoBehaviour
    {
        [SerializeField] private TabCollectionView _collectionView;
        
        private TabViewModel _viewModel;

        public void Bind(TabViewModel viewModel)
        {
            _viewModel = viewModel;
            Subscribe();
        }

        private void Subscribe()
        {
            _viewModel.FileEntries.CollectionChanged += HandleFileEntriesCollectionChanged;
        }

        private void HandleFileEntriesCollectionChanged(
            ReactiveCollectionChangedEventArgs<FileEntryViewModel> eventArgs)
        {
            switch (eventArgs.Action)
            {
                case NotifyCollectionChangedAction.Add:
                    _collectionView.AddEntries(eventArgs.NewItems);
                    break;
                case NotifyCollectionChangedAction.Remove:
                    _collectionView.RemoveEntries(eventArgs.OldItems);
                    break;
                case NotifyCollectionChangedAction.Reset:
                    _collectionView.Clear();
                    break;
            }
        }
    }
}