using System.Collections.Specialized;
using PhlegmaticOne.FileExplorer.ExplorerCore.ViewBase;
using PhlegmaticOne.FileExplorer.Features.Actions.Base;
using PhlegmaticOne.FileExplorer.Features.Actions.ViewModels;
using PhlegmaticOne.FileExplorer.Infrastructure.DependencyInjection.Attibutes;
using PhlegmaticOne.FileExplorer.Infrastructure.ViewModels;
using UnityEngine;
using UnityEngine.EventSystems;

namespace PhlegmaticOne.FileExplorer.Features.Actions.Views
{
    internal sealed class ActionsView : MonoBehaviour, IExplorerViewComponent, IPointerClickHandler
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
            _viewModel.Actions.CollectionChanged += ActionsOnCollectionChanged;
        }

        public void Unbind()
        {
            _viewModel.IsActive.ValueChanged -= IsActiveOnValueChanged;
            _viewModel.Position.ValueChanged -= PositionOnValueChanged;
            _viewModel.Actions.CollectionChanged -= ActionsOnCollectionChanged;
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            _viewModel.Deactivate();
        }

        private void ActionsOnCollectionChanged(ReactiveCollectionChangedEventArgs<IExplorerAction> eventArgs)
        {
            switch (eventArgs.Action)
            {
                case NotifyCollectionChangedAction.Add:
                    _actionDropdownView.AddActions(eventArgs.AffectedItems);
                    break;
                case NotifyCollectionChangedAction.Reset:
                    _actionDropdownView.Clear();
                    break;
            }
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