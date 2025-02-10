using PhlegmaticOne.FileExplorer.Features.Actions.ViewModels;
using PhlegmaticOne.FileExplorer.Infrastructure.DependencyInjection.Attibutes;
using PhlegmaticOne.FileExplorer.Services.StaticViews;
using UnityEngine;
using UnityEngine.EventSystems;

namespace PhlegmaticOne.FileExplorer.Features.Actions.Views
{
    internal sealed class ActionsView : MonoBehaviour, IExplorerStaticViewComponent, IPointerClickHandler
    {
        [SerializeField] private ActionDropdownView _actionDropdownView;
        
        private ActionsViewModel _viewModel;

        [ViewInject]
        public void Construct(ActionsViewModel viewModel)
        {
            _viewModel = viewModel;
        }
        
        public void Bind()
        {
            _viewModel.IsActive.ValueChanged += IsActiveOnValueChanged;
            _viewModel.Position.ValueChanged += PositionOnValueChanged;
            _viewModel.Actions.CollectionChanged += _actionDropdownView.UpdateView;
        }

        public void Unbind()
        {
            _viewModel.IsActive.ValueChanged -= IsActiveOnValueChanged;
            _viewModel.Position.ValueChanged -= PositionOnValueChanged;
            _viewModel.Actions.CollectionChanged -= _actionDropdownView.UpdateView;
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            _viewModel.Deactivate();
        }

        private void PositionOnValueChanged(Vector3 position)
        {
            _actionDropdownView.SetPosition(position);
        }

        private void IsActiveOnValueChanged(bool isActive)
        {
            gameObject.SetActive(isActive);

            if (isActive)
            {
                Rebuild();
            }
        }

        private void Rebuild()
        {
            _actionDropdownView.Rebuild();
            _viewModel.RaiseUpdatePosition(_actionDropdownView.Size);
        }
    }
}