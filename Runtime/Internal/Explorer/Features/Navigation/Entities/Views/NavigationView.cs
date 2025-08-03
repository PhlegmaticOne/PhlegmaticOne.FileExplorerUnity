using PhlegmaticOne.FileExplorer.Features.CommonInterfaces;
using PhlegmaticOne.FileExplorer.Infrastructure.DependencyInjection.Attibutes;
using PhlegmaticOne.FileExplorer.Infrastructure.Views.Components.Buttons;
using UnityEngine;

namespace PhlegmaticOne.FileExplorer.Features.Navigation.Entities
{
    internal sealed class NavigationView : MonoBehaviour, IExplorerStaticViewComponent
    {
        [SerializeField] private ComponentButton _backButton;
        
        private NavigationViewModel _viewModel;

        [Inject]
        public void Construct(NavigationViewModel viewModel)
        {
            _viewModel = viewModel;
        }
        
        public void Bind()
        {
            _backButton.Bind(_viewModel.NavigateBackCommand);
        }

        public void Unbind()
        {
            _backButton.Release();
        }
    }
}