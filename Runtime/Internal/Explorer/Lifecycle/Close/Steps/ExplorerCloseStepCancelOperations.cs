using PhlegmaticOne.FileExplorer.Services.Cancellation;

namespace PhlegmaticOne.FileExplorer.Lifecycle.Close.Steps
{
    internal sealed class ExplorerCloseStepCancelOperations : IExplorerCloseStep
    {
        private readonly IExplorerCancellationProvider _cancellationProvider;

        public ExplorerCloseStepCancelOperations(
            IExplorerCancellationProvider cancellationProvider)
        {
            _cancellationProvider = cancellationProvider;
        }
        
        public void ProcessClose()
        {
            _cancellationProvider.Cancel();
        }
    }
}