using PhlegmaticOne.FileExplorer.Infrastructure.Popups;

namespace PhlegmaticOne.FileExplorer.Features.Actions.Implementations.Rename.Views
{
    internal sealed class RenameInputPopupViewModel : PopupViewModel
    {
        public string AcceptButtonText { get; set; }
        public string HeaderText { get; set; }
        public string InitialInputText { get; set; }
        public string OutputText { get; set; }
    }
}