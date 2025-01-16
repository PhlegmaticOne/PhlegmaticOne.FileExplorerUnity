using PhlegmaticOne.FileExplorer.States;

namespace PhlegmaticOne.FileExplorer
{
    internal sealed class ExplorerEntryPoint
    {
        private readonly IExplorerStates _states;

        public ExplorerEntryPoint(IExplorerStates states)
        {
            _states = states;
        }

        public void Start()
        {
            _states.Open();
        }
    }
}