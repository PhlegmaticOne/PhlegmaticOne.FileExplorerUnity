using PhlegmaticOne.FileExplorer.Infrastructure.Popups;
using PhlegmaticOne.FileExplorer.Infrastructure.Views.Components;
using UnityEngine;

namespace PhlegmaticOne.FileExplorer.Popups.Errors
{
    internal sealed class ErrorPopup : PopupView<ErrorPopupViewModel>
    {
        [SerializeField] private ComponentText _titleText;
        [SerializeField] private ComponentText _errorNameText;
        [SerializeField] private ComponentText _errorDescriptionText;

        protected override void OnInitializing()
        {
            _titleText.Bind(ViewModel.Title);
            _errorNameText.Bind(ViewModel.ErrorName);
            _errorDescriptionText.Bind(ViewModel.Message);
            base.OnInitializing();
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