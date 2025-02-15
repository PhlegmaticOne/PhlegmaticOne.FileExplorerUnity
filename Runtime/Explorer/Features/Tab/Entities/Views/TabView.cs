using PhlegmaticOne.FileExplorer.Infrastructure.DependencyInjection.Attibutes;
using PhlegmaticOne.FileExplorer.Services.StaticViews;
using UnityEngine;

namespace PhlegmaticOne.FileExplorer.Features.Tab.Entities
{
    internal sealed class TabView : MonoBehaviour, IExplorerStaticViewComponent
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