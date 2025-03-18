using System.Threading;
using System.Threading.Tasks;

namespace PhlegmaticOne.FileExplorer
{
    public interface IExplorer
    {
        Task Open(CancellationToken token = default);
    }
}