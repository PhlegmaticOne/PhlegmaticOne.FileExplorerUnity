using System.Threading;

namespace PhlegmaticOne.FileExplorer.Services.Cancellation
{
    internal sealed class ExplorerCancellationProvider : IExplorerCancellationProvider
    {
        private CancellationTokenSource _cancellationTokenSource;
        
        public ExplorerCancellationProvider()
        {
            _cancellationTokenSource = new CancellationTokenSource();
        }

        public CancellationToken Token => _cancellationTokenSource.Token;

        public void Cancel()
        {
            _cancellationTokenSource.Cancel();
            _cancellationTokenSource.Dispose();
            _cancellationTokenSource = new CancellationTokenSource();
        }
    }
}