using System.Collections.Specialized;
using PhlegmaticOne.FileExplorer.ExplorerCore.ViewBase;
using PhlegmaticOne.FileExplorer.Features.FileEntries.ViewModels;
using PhlegmaticOne.FileExplorer.Features.Tab.ViewModels;
using PhlegmaticOne.FileExplorer.Infrastructure.DependencyInjection.Attibutes;
using PhlegmaticOne.FileExplorer.Infrastructure.ViewModels;
using UnityEngine;

namespace PhlegmaticOne.FileExplorer.Features.Tab.Views
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