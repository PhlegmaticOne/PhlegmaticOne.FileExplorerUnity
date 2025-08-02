using System.Threading;
using System.Threading.Tasks;

namespace PhlegmaticOne.FileExplorer.Features.FileEntries.Services.Icons
{
    internal interface IWebFileLoader
    {
        Task<WebLoadResult<byte[]>> LoadAsync(string url, float timeout, CancellationToken cancellationToken);
    }
}