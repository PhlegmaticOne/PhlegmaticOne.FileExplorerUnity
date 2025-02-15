using System.Threading;
using System.Threading.Tasks;

namespace PhlegmaticOne.FileExplorer.Features.Actions.ViewModels.Common
{
    internal interface IActionCommand
    {
        Task ExecuteAction(CancellationToken token);
    }
}