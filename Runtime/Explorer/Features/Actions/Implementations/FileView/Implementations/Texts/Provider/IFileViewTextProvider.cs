using System.Threading;
using System.Threading.Tasks;
using PhlegmaticOne.FileExplorer.Features.FileEntries.ViewModels;

namespace PhlegmaticOne.FileExplorer.Features.Actions.Implementations.FileView.Implementations
{
    internal interface IFileViewTextProvider
    {
        Task ViewTextAsync(FileEntryViewModel file, CancellationToken token);
    }
}