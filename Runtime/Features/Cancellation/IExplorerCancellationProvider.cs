using System.Threading;

namespace PhlegmaticOne.FileExplorer.Features.Cancellation
{
    internal interface IExplorerCancellationProvider
    {
        CancellationToken Token { get; }
        void Cancel();
    }
}