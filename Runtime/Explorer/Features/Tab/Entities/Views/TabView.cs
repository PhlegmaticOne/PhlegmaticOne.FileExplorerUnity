using PhlegmaticOne.FileExplorer.Infrastructure.DependencyInjection.Attibutes;
using PhlegmaticOne.FileExplorer.Services.StaticViews;
using UnityEngine;

namespace PhlegmaticOne.FileExplorer.Features.Tab.Entities
{
    internal sealed class TabView : MonoBehaviour, IExplorerStaticViewComponent
    {
        [SerializeField] private ComponentCollectionFileEntries _collectionView;
        
        private TabViewModel _viewModel;

        [ViewInject]
        public void Construct(TabViewModel viewModel)
        {
            _viewModel = viewModel;
        }
        
        public void Bind()
        {
            _collectionView.Bind(_viewModel.FileEntries);
        }

        public void Unbind()
        {
            _collectionView.Release();
        }
    }
}