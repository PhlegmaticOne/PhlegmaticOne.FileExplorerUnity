using System.Collections.Specialized;
using PhlegmaticOne.FileExplorer.Core.FileEntries.ViewModels;
using PhlegmaticOne.FileExplorer.Core.Tab.ViewModels;
using PhlegmaticOne.FileExplorer.Features.Views;
using PhlegmaticOne.FileExplorer.Infrastructure.DependencyInjection.Attibutes;
using PhlegmaticOne.FileExplorer.Infrastructure.ViewModels;
using UnityEngine;

namespace PhlegmaticOne.FileExplorer.Core.Tab.Views
{
    internal sealed class TabView : MonoBehaviour, IExplorerViewComponent
    {
        [SerializeField] private TabCollectionView _collectionView;
        
        private TabViewModel _viewModel;

        [ViewInject]
        public void Construct(TabViewModel viewModel)
        {
            _viewModel = viewModel;
        }
        
        public void Bind()
        {
            _viewModel.FileEntries.CollectionChanged += HandleFileEntriesCollectionChanged;
        }

        public void Unbind()
        {
            _viewModel.FileEntries.CollectionChanged -= HandleFileEntriesCollectionChanged;
        }

        private void HandleFileEntriesCollectionChanged(
            ReactiveCollectionChangedEventArgs<FileEntryViewModel> eventArgs)
        {
            switch (eventArgs.Action)
            {
                case NotifyCollectionChangedAction.Add:
                    _collectionView.AddEntries(eventArgs.AffectedItems);
                    break;
                case NotifyCollectionChangedAction.Remove:
                    _collectionView.RemoveEntries(eventArgs.AffectedItems);
                    break;
                case NotifyCollectionChangedAction.Reset:
                    _collectionView.Clear();
                    break;
            }
        }
    }
}