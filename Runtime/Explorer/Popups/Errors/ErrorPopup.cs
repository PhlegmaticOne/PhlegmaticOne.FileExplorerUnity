using PhlegmaticOne.FileExplorer.Infrastructure.Popups;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace PhlegmaticOne.FileExplorer.Popups.Errors
{
    internal sealed class ErrorPopup : PopupViewAsync<ErrorPopupViewModel>
    {
        [SerializeField] private TextMeshProUGUI _fileDescriptionText;
        [SerializeField] private TextMeshProUGUI _errorNameText;
        [SerializeField] private TextMeshProUGUI _errorDescriptionText;
        [SerializeField] private Button _closeButton;

        protected override void OnInitializing()
        {
            _closeButton.onClick.AddListener(Close);
        }

        protected override void OnShowing(ErrorPopupViewModel viewModel)
        {
            _fileDescriptionText.text = viewModel.GetFileDescription();
            _errorNameText.text = viewModel.GetErrorName();
            _errorDescriptionText.text = viewModel.GetErrorMessage();
        }

        public override void Release()
        {
            _closeButton.onClick.RemoveListener(Close);
        }
    }
}