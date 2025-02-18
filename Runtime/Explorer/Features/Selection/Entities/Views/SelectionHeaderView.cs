using PhlegmaticOne.FileExplorer.Features.Actions.Services.Positioning;
using PhlegmaticOne.FileExplorer.Infrastructure.DependencyInjection.Attibutes;
using PhlegmaticOne.FileExplorer.Infrastructure.Views.Components;
using PhlegmaticOne.FileExplorer.Infrastructure.Views.Components.Buttons;
using PhlegmaticOne.FileExplorer.Services.Scene;
using PhlegmaticOne.FileExplorer.Services.StaticViews;
using UnityEngine;

namespace PhlegmaticOne.FileExplorer.Features.Selection.Entities
{
    internal sealed class SelectionHeaderView : MonoBehaviour, IExplorerStaticViewComponent
    {
        [SerializeField] private ComponentButton _actionsButton;
        [SerializeField] private ComponentButton _clearSelectionButton;
        [SerializeField] private ComponentActiveObject _selectionContainerActiveObject;
        [SerializeField] private ComponentSelectionContainerLayout _selectionContainerLayout;
        [SerializeField] private ComponentSelectionDescription _selectionDescription;
        [SerializeField] private ComponentToggle _selectDeselectAllToggle;
        
        [SerializeField] private RectTransform _dropdownButtonRect;
        [SerializeField] private RectTransform _rectTransform;
        
        private SelectionViewModel _viewModel;
        private ISceneService _sceneService;

        [ViewInject]
        public void Construct(SelectionViewModel viewModel, ISceneService sceneService)
        {
            _sceneService = sceneService;
            _viewModel = viewModel;
        }
        
        public void Bind()
        {
            _actionsButton.Bind(_viewModel.ActionsCommand, CalculateViewPosition);
            _clearSelectionButton.Bind(_viewModel.ClearSelectionCommand);
            _selectionContainerActiveObject.Bind(_viewModel.IsSelectionActive);
            _selectionContainerLayout.Bind(_viewModel.IsSelectionActive);
            _selectionDescription.Bind(_viewModel.SelectedEntriesCount);
            _selectDeselectAllToggle.Bind(_viewModel.IsAllSelected, _viewModel.SelectDeselectCommand);
        }

        public void Unbind()
        {
            _actionsButton.Release();
            _clearSelectionButton.Release();
            _selectionContainerActiveObject.Release();
            _selectionContainerLayout.Release();
            _selectionDescription.Release();
            _selectDeselectAllToggle.Release();
        }

        private ActionTargetViewPosition CalculateViewPosition()
        {
            var buttonRect = _dropdownButtonRect.rect;
            var containerPosition = _rectTransform.anchoredPosition;
            
            return new ActionTargetViewPosition(
                new Vector2(containerPosition.x - buttonRect.width / 2, containerPosition.y),
                new Vector2(buttonRect.width, _rectTransform.rect.height),
                _sceneService.GetSafeZoneOffset());
        }
    }
}