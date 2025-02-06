using System.Threading;
using System.Threading.Tasks;
using PhlegmaticOne.FileExplorer.Features.FileEntries.ViewModels;

namespace PhlegmaticOne.FileExplorer.Popups.FileView
{
    internal interface IFileTextLoader
    {
        Task<FileViewContent<string>> GetText(FileEntryViewModel file, CancellationToken token);
    }
}