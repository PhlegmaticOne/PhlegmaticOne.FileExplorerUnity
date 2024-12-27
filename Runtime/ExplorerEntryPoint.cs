using PhlegmaticOne.FileExplorer.ExplorerCore.States;

namespace PhlegmaticOne.FileExplorer
{
    internal sealed class ExplorerEntryPoint
    {
        private readonly IExplorerStateProvider _stateProvider;

        public ExplorerEntryPoint(IExplorerStateProvider stateProvider)
        {
            _stateProvider = stateProvider;
        }

        public void Start()
        {
            _stateProvider.Show();
        }
    }
}