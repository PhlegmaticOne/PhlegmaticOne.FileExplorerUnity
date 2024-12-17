using PhlegmaticOne.FileExplorer.Core.FileEntries;
using PhlegmaticOne.FileExplorer.Core.Selection.ViewModels;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace PhlegmaticOne.FileExplorer.Core.Selection.Views
{
    internal sealed class SelectionHeaderView : MonoBehaviour
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

        public void Bind(SelectionViewModel viewModel)
        {
            _viewModel = viewModel;
            Subscribe();
        }

        private void Subscribe()
        {
            _actionsButton.onClick.AddListener(OpenActionsDropdown);
            _clearSelectionButton.onClick.AddListener(ClearSelection);
            _selectDeselectAllToggle.onValueChanged.AddListener(SelectDeselectAll);
            _viewModel.IsSelectionActive.ValueChanged += UpdateSelectionIsActive;
            _viewModel.SelectedEntriesCount.ValueChanged += UpdateSelectionCountView;
            _viewModel.IsAllSelected.ValueChanged += UpdateIsAllSelected;
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
                _viewModel.ClearSelection(isDisableSelection: false);
            }
            else
            {
                _viewModel.SelectAll();
            }
        }

        private void ClearSelection()
        {
            _viewModel.ClearSelection();
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