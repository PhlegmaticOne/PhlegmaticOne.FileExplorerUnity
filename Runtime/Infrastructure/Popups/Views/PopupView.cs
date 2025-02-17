using PhlegmaticOne.FileExplorer.Infrastructure.Views;
using PhlegmaticOne.FileExplorer.Infrastructure.Views.Components.Buttons;
using UnityEngine;

namespace PhlegmaticOne.FileExplorer.Infrastructure.Popups
{
    internal abstract class PopupView : View
    {
        [SerializeField] private ComponentButton _closeButton;
        
        private PopupViewModel _viewModel;

        protected void SetViewModelBase(PopupViewModel viewModel)
        {
            _viewModel = viewModel;
        }

        protected sealed override void OnInitializing()
        {
            _closeButton.Bind(_viewModel.DiscardCommand);
        }

        public void Discard()
        {
            _viewModel.DiscardCommand.Execute(null);
        }

        public virtual void Close() { }

        public override void Release()
        {
            _closeButton.Release();
            _viewModel = null;
        }
    }
}