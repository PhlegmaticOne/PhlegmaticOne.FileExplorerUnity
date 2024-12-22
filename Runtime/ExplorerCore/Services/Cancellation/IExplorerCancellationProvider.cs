using System.Threading;

namespace PhlegmaticOne.FileExplorer.ExplorerCore.Services.Cancellation
{
    internal interface IExplorerCancellationProvider
    {
        CancellationToken Token { get; }
        void Cancel();
    }
}