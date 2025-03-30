using PhlegmaticOne.FileExplorer.Lifecycle.Close.Steps;

namespace PhlegmaticOne.FileExplorer.Lifecycle.Close
{
    internal sealed class ExplorerCloseCommand : IExplorerCloseCommand
    {
        private readonly IExplorerCloseStep[] _closeSteps;

        public ExplorerCloseCommand(
            IExplorerCloseStep[] closeSteps)
        {
            _closeSteps = closeSteps;
        }
        
        public void Close()
        {
            foreach (var closeStep in _closeSteps)
            {
                closeStep.ProcessClose();
            }
        }
    }
}