using System.Threading;
using System.Threading.Tasks;
using PhlegmaticOne.FileExplorer.Features.FileEntries.ViewModels;

namespace PhlegmaticOne.FileExplorer.Features.FileEntries.Actions
{
    internal interface IFileEntryAction
    {
        Task ExecuteAction(FileEntryViewModel fileEntry, CancellationToken token);
    }
}