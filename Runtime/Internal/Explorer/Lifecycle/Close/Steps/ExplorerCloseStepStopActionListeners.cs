using PhlegmaticOne.FileExplorer.Features.CommonInterfaces;

namespace PhlegmaticOne.FileExplorer.Lifecycle.Close.Steps
{
    internal sealed class ExplorerCloseStepStopActionListeners : IExplorerCloseStep
    {
        private readonly IExplorerActionListener[] _actionListeners;

        public ExplorerCloseStepStopActionListeners(
            IExplorerActionListener[] actionListeners)
        {
            _actionListeners = actionListeners;
        }
        
        public void ProcessClose()
        {
            foreach (var actionListener in _actionListeners)
            {
                actionListener.Stop();
            }
        }
    }
}