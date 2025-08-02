using System.Threading;
using System.Threading.Tasks;
using PhlegmaticOne.FileExplorer.Features.FileEntries.Entities;

namespace PhlegmaticOne.FileExplorer.Popups.FileView
{
    internal interface IFileViewTextProvider
    {
        Task ViewTextAsync(FileEntryViewModel file, CancellationToken token);
    }
}