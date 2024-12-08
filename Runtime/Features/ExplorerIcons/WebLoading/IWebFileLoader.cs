using System.Threading.Tasks;

namespace PhlegmaticOne.FileExplorer.Features.ExplorerIcons.WebLoading
{
    internal interface IWebFileLoader
    {
        Task<WebLoadResult<byte[]>> LoadAsync(string url);
    }
}