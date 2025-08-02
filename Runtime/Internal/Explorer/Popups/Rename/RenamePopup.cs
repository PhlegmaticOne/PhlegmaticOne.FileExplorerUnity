using PhlegmaticOne.FileExplorer.Infrastructure.Popups;
using PhlegmaticOne.FileExplorer.Infrastructure.Views.Components;
using PhlegmaticOne.FileExplorer.Infrastructure.Views.Components.Buttons;
using UnityEngine;

namespace PhlegmaticOne.FileExplorer.Popups.Rename
{
    internal sealed class RenamePopup : PopupView<RenamePopupViewModel>
    {
        [SerializeField] private ComponentInput _inputField;
        [SerializeField] private ComponentText _headerText;
        [SerializeField] private ComponentButton _acceptButton;

        protected override void OnInitializing()
        {
            _acceptButton.Bind(ViewModel.CloseCommand);
            _inputField.Bind(ViewModel.OutputText);
            _headerText.Bind(ViewModel.HeaderText);
            base.OnInitializing();
        }

        public override void Release()
        {
            _acceptButton.Release();
            _inputField.Release();
            _headerText.Release();
            base.Release();
        }
    }
}