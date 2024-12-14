using PhlegmaticOne.FileExplorer.Infrastructure.Views;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace PhlegmaticOne.FileExplorer.Features.Views.Input
{
    internal sealed class InputPopup : ViewAsync<InputViewModel>
    {
        [SerializeField] private TMP_InputField _inputField;
        [SerializeField] private TextMeshProUGUI _headerText;
        [SerializeField] private TextMeshProUGUI _acceptButtonText;
        [SerializeField] private Button _acceptButton;
        [SerializeField] private Button _discardButton;

        protected override void OnShowing(InputViewModel viewModel)
        {
            _inputField.onValueChanged.AddListener(UpdateOutputText);
            _discardButton.onClick.AddListener(Discard);
            _acceptButton.onClick.AddListener(Close);
            
            _inputField.text = viewModel.InitialInputText;
            _headerText.text = viewModel.HeaderText;
            _acceptButtonText.text = viewModel.AcceptButtonText;
        }

        public override void Release()
        {
            _inputField.onValueChanged.RemoveListener(UpdateOutputText);
            _discardButton.onClick.RemoveListener(Discard);
            _acceptButton.onClick.RemoveListener(Close);
        }

        private void UpdateOutputText(string text)
        {
            ViewModel.OutputText = text;
        }
    }
}