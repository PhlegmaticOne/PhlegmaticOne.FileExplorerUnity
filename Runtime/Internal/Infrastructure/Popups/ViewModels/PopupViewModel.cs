using PhlegmaticOne.FileExplorer.Infrastructure.ViewModels;
using PhlegmaticOne.FileExplorer.Infrastructure.ViewModels.Commands;

namespace PhlegmaticOne.FileExplorer.Infrastructure.Popups
{
    internal abstract class PopupViewModel : ViewModel
    {
        private readonly IPopupProvider _popupProvider;

        protected PopupViewModel(IPopupProvider popupProvider)
        {
            _popupProvider = popupProvider;
            DiscardCommand = new CommandDelegateEmpty(Discard);
            CloseCommand = new CommandDelegateEmpty(Close);
        }

        public bool IsDiscarded { get; private set; }
        public ICommand DiscardCommand { get; }
        public ICommand CloseCommand { get; }

        private void Close()
        {
            _popupProvider.Close(this);
        }

        private void Discard()
        {
            IsDiscarded = true;
            Close();
        }
    }
}