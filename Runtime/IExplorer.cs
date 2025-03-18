using System.Threading;
using System.Threading.Tasks;

namespace PhlegmaticOne.FileExplorer
{
    public interface IExplorer
    {
        Task<ExplorerShowResult> Open(CancellationToken token = default);
    }
}