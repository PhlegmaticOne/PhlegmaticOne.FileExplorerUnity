using PhlegmaticOne.FileExplorer.Infrastructure.ViewModels;
using PhlegmaticOne.FileExplorer.States;

namespace PhlegmaticOne.FileExplorer.Features.Control.Entities
{
    internal sealed class ControlViewModel : ViewModel
    {
        private readonly IExplorerStates _states;

        public ControlViewModel(IExplorerStates states)
        {
            _states = states;
        }

        public void Close()
        {
            _states.Close();
        }
    }
}