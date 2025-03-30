using PhlegmaticOne.FileExplorer.Features.CommonInterfaces;
using PhlegmaticOne.FileExplorer.Infrastructure.DependencyInjection.Attibutes;
using PhlegmaticOne.FileExplorer.Infrastructure.Views.Components;
using PhlegmaticOne.FileExplorer.Infrastructure.Views.Components.Positions;
using UnityEngine;
using UnityEngine.EventSystems;

namespace PhlegmaticOne.FileExplorer.Features.Actions.Entities.Actions
{
    internal sealed class ActionsView : MonoBehaviour, IExplorerStaticViewComponent, IPointerClickHandler
    {
        [SerializeField] private ComponentCollectionActions _actionDropdownView;
        [SerializeField] private ComponentAnchoredPosition _anchoredPosition;
        [SerializeField] private ComponentActiveObject _activeObject;
        
        private ActionsViewModel _viewModel;

        [ViewInject]
        public void Construct(ActionsViewModel viewModel)
        {
            _viewModel = viewModel;
        }
        
        public void Bind()
        {
            _activeObject.Bind(_viewModel.IsActive);
            _anchoredPosition.Bind(_viewModel.Position);
            _actionDropdownView.Bind(_viewModel.Actions);
            _viewModel.Activated += Rebuild;
        }

        public void Unbind()
        {
            _activeObject.Release();
            _anchoredPosition.Release();
            _actionDropdownView.Release();
            _viewModel.Activated -= Rebuild;
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            _viewModel.Deactivate();
        }

        private void Rebuild()
        {
            _actionDropdownView.Rebuild();
            _viewModel.RaiseUpdatePosition(_actionDropdownView.Size);
        }
    }
}