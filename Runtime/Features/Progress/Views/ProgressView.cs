using PhlegmaticOne.FileExplorer.ExplorerCore.ViewBase;
using PhlegmaticOne.FileExplorer.Features.Progress.ViewModels;
using PhlegmaticOne.FileExplorer.Infrastructure.DependencyInjection.Attibutes;
using UnityEngine;

namespace PhlegmaticOne.FileExplorer.Features.Progress.Views
{
    internal sealed class ProgressView : MonoBehaviour, IExplorerViewComponent
    {
        [SerializeField] private RectTransform _parent;
        [SerializeField] private RectTransform _rectTransform;
        
        private ProgressViewModel _viewModel;

        [ViewInject]
        public void Construct(ProgressViewModel viewModel)
        {
            _viewModel = viewModel;
        }
        
        public void Bind()
        {
            _viewModel.IsActive.ValueChanged += UpdateProgressIsActive;
            _viewModel.Progress.ValueChanged += UpdateProgress;
        }

        public void Unbind()
        {
            _viewModel.IsActive.ValueChanged -= UpdateProgressIsActive;
            _viewModel.Progress.ValueChanged -= UpdateProgress;
        }

        private void UpdateProgressIsActive(bool isActive)
        {
            gameObject.SetActive(isActive);
        }

        private void UpdateProgress(float progress)
        {
            var width = _parent.rect.width * progress;
            _rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, width);
        }
    }
}