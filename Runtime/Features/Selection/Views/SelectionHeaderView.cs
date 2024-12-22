using PhlegmaticOne.FileExplorer.ExplorerCore.ViewBase;
using PhlegmaticOne.FileExplorer.Features.FileEntries.Services.Actions;
using PhlegmaticOne.FileExplorer.Features.Selection.ViewModels;
using PhlegmaticOne.FileExplorer.Features.Selection.Views.Data;
using PhlegmaticOne.FileExplorer.Infrastructure.DependencyInjection.Attibutes;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace PhlegmaticOne.FileExplorer.Features.Selection.Views
{
    internal sealed class SelectionHeaderView : MonoBehaviour, IExplorerViewComponent
    {
        [SerializeField] private VerticalLayoutGroup _offsetGroup;
        [SerializeField] private Button _actionsButton;
        [SerializeField] private Button _clearSelectionButton;
        [SerializeField] private Toggle _selectDeselectAllToggle;
        [SerializeField] private RectTransform _rectTransform;
        [SerializeField] private GameObject _searchBarContainer;
        [SerializeField] private GameObject _selectionCountContainer;
        [SerializeField] private TextMeshProUGUI _selectionCountText;
        
        private SelectionViewModel _viewModel;

        [ViewInject]
        public void Construct(SelectionViewModel viewModel)
        {
            _viewModel = viewModel;
        }
        
        public void Bind()
        {
            _actionsButton.onClick.AddListener(OpenActionsDropdown);
            _clearSelectionButton.onClick.AddListener(ClearSelection);
            _selectDeselectAllToggle.onValueChanged.AddListener(SelectDeselectAll);
            _viewModel.IsSelectionActive.ValueChanged += UpdateSelectionIsActive;
            _viewModel.SelectedEntriesCount.ValueChanged += UpdateSelectionCountView;
            _viewModel.IsAllSelected.ValueChanged += UpdateIsAllSelected;
        }

        public void Unbind()
        {
            _actionsButton.onClick.RemoveListener(OpenActionsDropdown);
            _clearSelectionButton.onClick.RemoveListener(ClearSelection);
            _selectDeselectAllToggle.onValueChanged.RemoveListener(SelectDeselectAll);
            _viewModel.IsSelectionActive.ValueChanged -= UpdateSelectionIsActive;
            _viewModel.SelectedEntriesCount.ValueChanged -= UpdateSelectionCountView;
            _viewModel.IsAllSelected.ValueChanged -= UpdateIsAllSelected;
        }
        
        private void OpenActionsDropdown()
        {
            _viewModel.Position.Update(
                _rectTransform.anchoredPosition, 
                _rectTransform.rect.size, 
                _offsetGroup.padding.top);
            
            _viewModel.OnSelectionActionsClick();
        }

        private void SelectDeselectAll(bool isSelected)
        {
            if (_viewModel.IsAllSelected)
            {
                _viewModel.Clear(isDisableSelection: false);
            }
            else
            {
                _viewModel.SelectAll();
            }
        }

        private void ClearSelection()
        {
            _viewModel.Clear();
        }

        private void UpdateSelectionCountView(FileEntriesCounter counter)
        {
            var description = new SelectionHeaderViewDescription(counter.TotalCount);
            _selectionCountText.text = description.GetDescription();
        }

        private void UpdateIsAllSelected(bool isAllSelected)
        {
            _selectDeselectAllToggle.SetIsOnWithoutNotify(isAllSelected);
        }

        private void UpdateSelectionIsActive(bool isActive)
        {
            _searchBarContainer.SetActive(!isActive);
            _selectionCountContainer.SetActive(isActive);
        }
    }
}