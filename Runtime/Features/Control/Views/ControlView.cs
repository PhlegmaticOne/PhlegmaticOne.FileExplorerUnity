using PhlegmaticOne.FileExplorer.ExplorerCore.ViewBase;
using PhlegmaticOne.FileExplorer.Features.Control.ViewModels;
using PhlegmaticOne.FileExplorer.Infrastructure.DependencyInjection.Attibutes;
using UnityEngine;
using UnityEngine.UI;

namespace PhlegmaticOne.FileExplorer.Features.Control.Views
{
    internal sealed class ControlView : MonoBehaviour, IExplorerViewComponent
    {
        [SerializeField] private Button _closeButton;
        
        private ControlViewModel _viewModel;

        [ViewInject]
        public void Construct(ControlViewModel viewModel)
        {
            _viewModel = viewModel;
        }

        public void Bind()
        {
            _closeButton.onClick.AddListener(CloseExplorer);
        }

        public void Unbind()
        {
            _closeButton.onClick.RemoveListener(CloseExplorer);
        }

        private void CloseExplorer()
        {
            _viewModel.Close();
        }
    }
}