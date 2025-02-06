using PhlegmaticOne.FileExplorer.Infrastructure.Popups;

namespace PhlegmaticOne.FileExplorer.Popups.Rename
{
    internal sealed class RenamePopupViewModel : PopupViewModel
    {
        public string AcceptButtonText { get; set; }
        public string HeaderText { get; set; }
        public string InitialInputText { get; set; }
        public string OutputText { get; set; }
    }
}