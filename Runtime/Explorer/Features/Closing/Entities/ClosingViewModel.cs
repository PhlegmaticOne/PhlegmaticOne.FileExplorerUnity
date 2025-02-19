using PhlegmaticOne.FileExplorer.Infrastructure.ViewModels;
using PhlegmaticOne.FileExplorer.Infrastructure.ViewModels.Commands;
using PhlegmaticOne.FileExplorer.States;

namespace PhlegmaticOne.FileExplorer.Features.Closing.Entities
{
    internal sealed class ClosingViewModel : ViewModel
    {
        private readonly IExplorerStates _states;

        public ClosingViewModel(IExplorerStates states)
        {
            _states = states;
            CloseCommand = new CommandDelegateEmpty(Close);
        }
        
        public ICommand CloseCommand { get; }

        private void Close()
        {
            _states.Close();
        }
    }
}