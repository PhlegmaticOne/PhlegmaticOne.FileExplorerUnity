using System.Threading;

namespace PhlegmaticOne.FileExplorer.Services.Cancellation
{
    internal interface IExplorerCancellationProvider
    {
        CancellationToken Token { get; }
        void Cancel();
    }
}