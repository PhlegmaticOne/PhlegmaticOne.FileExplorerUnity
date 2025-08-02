using PhlegmaticOne.FileExplorer.Features.CommonInterfaces;
using PhlegmaticOne.FileExplorer.Infrastructure.DependencyInjection.Attibutes;
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