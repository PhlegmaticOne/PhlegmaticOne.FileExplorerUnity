using PhlegmaticOne.FileExplorer.Features.HeaderInfo.Entities.Components;
using PhlegmaticOne.FileExplorer.Infrastructure.DependencyInjection.Attibutes;
using PhlegmaticOne.FileExplorer.Infrastructure.Views.Components;
using PhlegmaticOne.FileExplorer.Services.StaticViews;
using UnityEngine;

namespace PhlegmaticOne.FileExplorer.Features.HeaderInfo.Entities
{
    internal sealed class HeaderInfoView : MonoBehaviour, IExplorerStaticViewComponent
    {
        [SerializeField] private ComponentActiveObject _activeObject;
        [SerializeField] private ComponentProgressSetter _progressSetter;
        [SerializeField] private ComponentText _infoText;
        
        private HeaderInfoViewModel _viewModel;

        [ViewInject]
        public void Construct(HeaderInfoViewModel viewModel)
        {
            _viewModel = viewModel;
        }
        
        public void Bind()
        {
            _activeObject.Bind(_viewModel.IsActive);
            _progressSetter.Bind(_viewModel.Progress);
            _infoText.Bind(_viewModel.InfoMessage);
        }

        public void Unbind()
        {
            _activeObject.Release();
            _progressSetter.Release();
        }
    }
}