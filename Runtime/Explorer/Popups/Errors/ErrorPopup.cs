using PhlegmaticOne.FileExplorer.Infrastructure.Popups;
using TMPro;
using UnityEngine;

namespace PhlegmaticOne.FileExplorer.Popups.Errors
{
    internal sealed class ErrorPopup : PopupViewAsync<ErrorPopupViewModel>
    {
        [SerializeField] private TextMeshProUGUI _fileDescriptionText;
        [SerializeField] private TextMeshProUGUI _errorNameText;
        [SerializeField] private TextMeshProUGUI _errorDescriptionText;

        protected override void OnShowing(ErrorPopupViewModel viewModel)
        {
            _fileDescriptionText.text = viewModel.GetFileDescription();
            _errorNameText.text = viewModel.GetErrorName();
            _errorDescriptionText.text = viewModel.GetErrorMessage();
        }
    }
}