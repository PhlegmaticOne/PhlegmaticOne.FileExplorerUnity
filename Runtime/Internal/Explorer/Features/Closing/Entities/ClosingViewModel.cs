using PhlegmaticOne.FileExplorer.Infrastructure.ViewModels;
using PhlegmaticOne.FileExplorer.Infrastructure.ViewModels.Commands;
using PhlegmaticOne.FileExplorer.Lifecycle.Close;

namespace PhlegmaticOne.FileExplorer.Features.Closing.Entities
{
    internal sealed class ClosingViewModel : ViewModel
    {
        private readonly IExplorerCloseCommand _closeCommand;

        public ClosingViewModel(IExplorerCloseCommand closeCommand)
        {
            _closeCommand = closeCommand;
            CloseCommand = new CommandDelegateEmpty(Close);
        }
        
        public ICommand CloseCommand { get; }

        private void Close()
        {
            _closeCommand.Close();
        }
    }
}