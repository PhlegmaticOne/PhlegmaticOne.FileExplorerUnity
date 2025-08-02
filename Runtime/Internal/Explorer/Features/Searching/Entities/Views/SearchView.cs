using PhlegmaticOne.FileExplorer.Features.CommonInterfaces;
using PhlegmaticOne.FileExplorer.Infrastructure.DependencyInjection.Attibutes;
using PhlegmaticOne.FileExplorer.Infrastructure.Views.Components;
using PhlegmaticOne.FileExplorer.Infrastructure.Views.Components.Buttons;
using UnityEngine;

namespace PhlegmaticOne.FileExplorer.Features.Searching.Entities
{
    internal sealed class SearchView : MonoBehaviour, IExplorerStaticViewComponent
    {
        [SerializeField] private ComponentInput _searchInput;
        [SerializeField] private ComponentButton _resetButton;
        [SerializeField] private ComponentActiveObject _activeObject;
        
        private SearchViewModel _viewModel;

        [ViewInject]
        public void Construct(SearchViewModel viewModel)
        {
            _viewModel = viewModel;
        }
        
        public void Bind()
        {
            _searchInput.Bind(_viewModel.SearchText, _viewModel.SearchCommand);
            _resetButton.Bind(_viewModel.ResetCommand);
            _activeObject.Bind(_viewModel.IsActive);
        }

        public void Unbind()
        {
            _searchInput.Release();
            _resetButton.Release();
            _activeObject.Release();
        }
    }
}