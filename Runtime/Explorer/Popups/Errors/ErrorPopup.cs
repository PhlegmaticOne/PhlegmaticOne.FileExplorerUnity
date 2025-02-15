using PhlegmaticOne.FileExplorer.Infrastructure.Popups;
using TMPro;
using UnityEngine;

namespace PhlegmaticOne.FileExplorer.Popups.Errors
{
    internal sealed class ErrorPopup : PopupViewAsync<ErrorPopupViewModel>
    {
        [SerializeField] private TextMeshProUGUI _titleText;
        [SerializeField] private TextMeshProUGUI _errorNameText;
        [SerializeField] private TextMeshProUGUI _errorDescriptionText;

        protected override void OnShowing(ErrorPopupViewModel viewModel)
        {
            _titleText.text = viewModel.Title;
            _errorNameText.text = viewModel.ErrorName;
            _errorDescriptionText.text = viewModel.Message;
        }
    }
}