using PhlegmaticOne.FileExplorer.Features.CommonInterfaces;
using PhlegmaticOne.FileExplorer.Infrastructure.DependencyInjection.Attibutes;
using PhlegmaticOne.FileExplorer.Infrastructure.Views.Components;
using UnityEngine;

namespace PhlegmaticOne.FileExplorer.Features.ScreenMessages.Entities
{
    internal sealed class ScreenMessagesView : MonoBehaviour, IExplorerStaticViewComponent
    {
        [SerializeField] private ComponentActiveObject _activeObject;
        [SerializeField] private ComponentText _text;
        
        private ScreenMessagesViewModel _viewModel;

        [ViewInject]
        public void Construct(ScreenMessagesViewModel viewModel)
        {
            _viewModel = viewModel;
        }
        
        public void Bind()
        {
            _activeObject.Bind(_viewModel.IsTabCenterMessageActive);
            _text.Bind(_viewModel.TabCenterMessage);
        }

        public void Unbind()
        {
            _activeObject.Release();
            _text.Release();
        }
    }
}