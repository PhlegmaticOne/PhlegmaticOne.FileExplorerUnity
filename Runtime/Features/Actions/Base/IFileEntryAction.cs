using System.Threading.Tasks;

namespace PhlegmaticOne.FileExplorer.Features.Actions
{
    internal interface IFileEntryAction
    {
        string Description { get; }
        FileEntryActionColor Color { get; }
        Task<bool> Execute();
    }
}