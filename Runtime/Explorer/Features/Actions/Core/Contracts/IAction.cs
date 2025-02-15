using System.Threading;
using System.Threading.Tasks;

namespace PhlegmaticOne.FileExplorer.Features.Actions.Core
{
    internal interface IAction
    {
        Task Execute(CancellationToken token);
    }
}