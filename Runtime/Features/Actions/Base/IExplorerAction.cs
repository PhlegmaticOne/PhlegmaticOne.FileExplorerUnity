using System.Threading.Tasks;

namespace PhlegmaticOne.FileExplorer.Features.Actions.Base
{
    internal interface IExplorerAction
    {
        string Description { get; }
        ExplorerActionColor Color { get; }
        Task<bool> Execute();
    }
}