using PhlegmaticOne.FileExplorer.Infrastructure.Popups;
using PhlegmaticOne.FileExplorer.Infrastructure.Views.Components;
using UnityEngine;

namespace PhlegmaticOne.FileExplorer.Popups.Errors
{
    internal sealed class ErrorPopup : PopupViewAsync<ErrorPopupViewModel>
    {
        [SerializeField] private ComponentText _titleText;
        [SerializeField] private ComponentText _errorNameText;
        [SerializeField] private ComponentText _errorDescriptionText;

        protected override void OnShowing(ErrorPopupViewModel viewModel)
        {
            _titleText.Bind(viewModel.Title);
            _errorNameText.Bind(viewModel.ErrorName);
            _errorDescriptionText.Bind(viewModel.Message);
        }

        public override void Release()
        {
            _titleText.Release();
            _errorNameText.Release();
            _errorDescriptionText.Release();
            base.Release();
        }
    }
}