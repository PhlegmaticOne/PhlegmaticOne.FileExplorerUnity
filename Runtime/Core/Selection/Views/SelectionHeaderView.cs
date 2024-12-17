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
            _viewModel.IsSelectionActive.ValueChanged += UpdateSelectionIsActive;
            _viewModel.SelectedEntriesCount.ValueChanged += UpdateSelectionCountView;
        }

        private void OpenActionsDropdown()
        {
            _viewModel.Position.Update(
                _rectTransform.anchoredPosition, 
                _rectTransform.rect.size, 
                _offsetGroup.padding.top);
            
            _viewModel.OnSelectionActionsClick();
        }

        private void UpdateSelectionCountView(FileEntriesCounter counter)
        {
            var viewText = $"Files: {counter.FilesCount}, Directories: {counter.DirectoriesCount}";
            _selectionCountText.text = viewText;
        }

        private void UpdateSelectionIsActive(bool isActive)
        {
            _searchBarContainer.SetActive(!isActive);
            _selectionCountContainer.SetActive(isActive);
        }
    }
}