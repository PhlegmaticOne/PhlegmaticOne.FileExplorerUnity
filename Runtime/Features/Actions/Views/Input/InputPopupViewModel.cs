using PhlegmaticOne.FileExplorer.Infrastructure.Popups;

namespace PhlegmaticOne.FileExplorer.Features.Actions.Views.Input
{
    internal sealed class InputPopupViewModel : PopupViewModel
    {
        public string AcceptButtonText { get; set; }
        public string HeaderText { get; set; }
        public string InitialInputText { get; set; }
        public string OutputText { get; set; }
    }
}