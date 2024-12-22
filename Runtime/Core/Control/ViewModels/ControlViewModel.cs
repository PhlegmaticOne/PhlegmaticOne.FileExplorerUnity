using PhlegmaticOne.FileExplorer.States;

namespace PhlegmaticOne.FileExplorer.Core.Explorer.ViewModels
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