using PhlegmaticOne.FileExplorer.Infrastructure.DependencyInjection.Attibutes;
using PhlegmaticOne.FileExplorer.Infrastructure.Views.Components.Buttons;
using PhlegmaticOne.FileExplorer.Services.StaticViews;
using UnityEngine;

namespace PhlegmaticOne.FileExplorer.Features.Control.Entities
{
    internal sealed class ControlView : MonoBehaviour, IExplorerStaticViewComponent
    {
        [SerializeField] private ComponentButton _closeButton;
        
        private ControlViewModel _viewModel;

        [ViewInject]
        public void Construct(ControlViewModel viewModel)
        {
            _viewModel = viewModel;
        }

        public void Bind()
        {
            _closeButton.Bind(_viewModel.CloseCommand);
        }

        public void Unbind()
        {
            _closeButton.Release();
        }
    }
}