using PhlegmaticOne.FileExplorer.Features.CommonInterfaces;

namespace PhlegmaticOne.FileExplorer.Lifecycle.Show.Steps
{
    internal sealed class ExplorerShowStepStartActionListeners : IExplorerShowStep
    {
        private readonly IExplorerActionListener[] _listeners;

        public ExplorerShowStepStartActionListeners(IExplorerActionListener[] listeners)
        {
            _listeners = listeners;
        }
        
        public void ProcessShow()
        {
            foreach (var listener in _listeners)
            {
                listener.Start();
            }
        }
    }
}