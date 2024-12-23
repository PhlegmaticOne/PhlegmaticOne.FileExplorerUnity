using PhlegmaticOne.FileExplorer.ExplorerCore.ViewBase;
using PhlegmaticOne.FileExplorer.Features.Tab.ViewModels;
using PhlegmaticOne.FileExplorer.Infrastructure.DependencyInjection.Attibutes;
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
            _viewModel.FileEntries.CollectionChanged += _collectionView.UpdateView;
        }

        public void Unbind()
        {
            _viewModel.FileEntries.CollectionChanged -= _collectionView.UpdateView;
        }
    }
}