using PhlegmaticOne.FileExplorer.Infrastructure.Popups;
using PhlegmaticOne.FileExplorer.Infrastructure.ViewModels;

namespace PhlegmaticOne.FileExplorer.Popups.Rename
{
    internal sealed class RenamePopupViewModel : PopupViewModel
    {
        public RenamePopupViewModel(IPopupProvider popupProvider) : base(popupProvider)
        {
            OutputText = new ReactiveProperty<string>(string.Empty);
            HeaderText = new ReactiveProperty<string>();
        }

        public ReactiveProperty<string> HeaderText { get; }
        public ReactiveProperty<string> OutputText { get; }

        public void Setup(string initialInputText, string headerText)
        {
            OutputText.SetValueNotify(initialInputText);
            HeaderText.SetValueNotify(headerText);
        }
    }
}