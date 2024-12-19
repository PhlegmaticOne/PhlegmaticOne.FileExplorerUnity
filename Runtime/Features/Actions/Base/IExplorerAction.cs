using System.Threading.Tasks;

namespace PhlegmaticOne.FileExplorer.Features.Actions
{
    internal interface IExplorerAction
    {
        string Description { get; }
        FileEntryActionColor Color { get; }
        Task<bool> Execute();
    }
}