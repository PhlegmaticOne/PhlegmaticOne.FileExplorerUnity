using PhlegmaticOne.FileExplorer.ExplorerCore.States;
using PhlegmaticOne.FileExplorer.Infrastructure.ViewModels;

namespace PhlegmaticOne.FileExplorer.Features.Control.ViewModels
{
    internal sealed class ControlViewModel : ViewModel
    {
        private readonly IExplorerStateProvider _stateProvider;

        public ControlViewModel(IExplorerStateProvider stateProvider)
        {
            _stateProvider = stateProvider;
        }

        public void Close()
        {
            _stateProvider.Close();
        }
    }
}