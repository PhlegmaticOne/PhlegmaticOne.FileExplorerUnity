using System.Threading;
using System.Threading.Tasks;
using PhlegmaticOne.FileExplorer.Features.FileEntries.Entities;

namespace PhlegmaticOne.FileExplorer.Popups.FileView
{
    internal interface IFileViewImageProvider
    {
        Task ViewImageAsync(FileEntryViewModel file, CancellationToken token);
    }
}