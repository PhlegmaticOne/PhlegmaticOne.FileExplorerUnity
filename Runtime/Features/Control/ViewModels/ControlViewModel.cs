using PhlegmaticOne.FileExplorer.ExplorerCore.States;

namespace PhlegmaticOne.FileExplorer.Features.Control.ViewModels
{
    internal sealed class ControlViewModel
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