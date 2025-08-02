using PhlegmaticOne.FileExplorer.Features.CommonInterfaces;
using PhlegmaticOne.FileExplorer.Infrastructure.DependencyInjection.Attibutes;
using PhlegmaticOne.FileExplorer.Infrastructure.Views.Components.Buttons;
using UnityEngine;

namespace PhlegmaticOne.FileExplorer.Features.Closing.Entities
{
    internal sealed class ClosingView : MonoBehaviour, IExplorerStaticViewComponent
    {
        [SerializeField] private ComponentButton _closeButton;
        
        private ClosingViewModel _viewModel;

        [ViewInject]
        public void Construct(ClosingViewModel viewModel)
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