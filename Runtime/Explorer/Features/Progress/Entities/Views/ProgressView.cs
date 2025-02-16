using PhlegmaticOne.FileExplorer.Features.Progress.Entities.Components;
using PhlegmaticOne.FileExplorer.Infrastructure.DependencyInjection.Attibutes;
using PhlegmaticOne.FileExplorer.Infrastructure.Views.Components;
using PhlegmaticOne.FileExplorer.Services.StaticViews;
using UnityEngine;

namespace PhlegmaticOne.FileExplorer.Features.Progress.Entities
{
    internal sealed class ProgressView : MonoBehaviour, IExplorerStaticViewComponent
    {
        [SerializeField] private ComponentActiveObject _activeObject;
        [SerializeField] private ComponentProgressSetter _progressSetter;
        
        private ProgressViewModel _viewModel;

        [ViewInject]
        public void Construct(ProgressViewModel viewModel)
        {
            _viewModel = viewModel;
        }
        
        public void Bind()
        {
            _activeObject.Bind(_viewModel.IsActive);
            _progressSetter.Bind(_viewModel.Progress);
        }

        public void Unbind()
        {
            _activeObject.Release();
            _progressSetter.Release();
        }
    }
}