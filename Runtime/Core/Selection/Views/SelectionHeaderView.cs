using PhlegmaticOne.FileExplorer.Core.Selection.ViewModels;
using UnityEngine;
using UnityEngine.UI;

namespace PhlegmaticOne.FileExplorer.Core.Selection.Views
{
    internal sealed class SelectionHeaderView : MonoBehaviour
    {
        [SerializeField] private VerticalLayoutGroup _offsetGroup;
        [SerializeField] private Button _actionsButton;
        [SerializeField] private RectTransform _rectTransform;
        
        private SelectionViewModel _viewModel;

        public void Bind(SelectionViewModel viewModel)
        {
            _viewModel = viewModel;
            _actionsButton.onClick.AddListener(OpenActionsDropdown);
        }

        private void OpenActionsDropdown()
        {
            _viewModel.Position.Update(
                _rectTransform.anchoredPosition, 
                _rectTransform.rect.size, 
                _offsetGroup.padding.top);
            
            _viewModel.OnSelectionActionsClick();
        }
    }
}