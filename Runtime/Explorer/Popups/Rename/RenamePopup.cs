using PhlegmaticOne.FileExplorer.Infrastructure.Popups;
using PhlegmaticOne.FileExplorer.Infrastructure.Views.Components;
using PhlegmaticOne.FileExplorer.Infrastructure.Views.Components.Buttons;
using UnityEngine;

namespace PhlegmaticOne.FileExplorer.Popups.Rename
{
    internal sealed class RenamePopup : PopupViewAsync<RenamePopupViewModel>
    {
        [SerializeField] private ComponentInput _inputField;
        [SerializeField] private ComponentText _headerText;
        [SerializeField] private ComponentButton _acceptButton;

        protected override void OnShowing(RenamePopupViewModel viewModel)
        {
            _acceptButton.Bind(viewModel.CloseCommand);
            _inputField.Bind(viewModel.OutputText);
            _headerText.Bind(viewModel.HeaderText);
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