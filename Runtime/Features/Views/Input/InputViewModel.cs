using PhlegmaticOne.FileExplorer.Infrastructure.Views;

namespace PhlegmaticOne.FileExplorer.Features.Views.Input
{
    internal sealed class InputViewModel : ViewModelBase
    {
        public string AcceptButtonText { get; set; }
        public string HeaderText { get; set; }
        public string InitialInputText { get; set; }
        public string OutputText { get; set; }
    }
}