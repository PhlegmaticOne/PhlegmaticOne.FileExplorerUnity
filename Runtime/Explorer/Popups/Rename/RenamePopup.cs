using PhlegmaticOne.FileExplorer.Infrastructure.Popups;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace PhlegmaticOne.FileExplorer.Popups.Rename
{
    internal sealed class RenamePopup : PopupViewAsync<RenamePopupViewModel>
    {
        [SerializeField] private TMP_InputField _inputField;
        [SerializeField] private TextMeshProUGUI _headerText;
        [SerializeField] private TextMeshProUGUI _acceptButtonText;
        [SerializeField] private Button _acceptButton;

        protected override void OnInitializing()
        {
            _inputField.onValueChanged.AddListener(UpdateOutputText);
            _acceptButton.onClick.AddListener(Close);
            base.OnInitializing();
        }

        protected override void OnShowing(RenamePopupViewModel popupViewModel)
        {
            _inputField.text = popupViewModel.InitialInputText;
            _headerText.text = popupViewModel.HeaderText;
            _acceptButtonText.text = popupViewModel.AcceptButtonText;
        }

        public override void Release()
        {
            _inputField.onValueChanged.RemoveListener(UpdateOutputText);
            _acceptButton.onClick.RemoveListener(Close);
            base.Release();
        }

        private void UpdateOutputText(string text)
        {
            PopupViewModel.OutputText = text;
        }
    }
}