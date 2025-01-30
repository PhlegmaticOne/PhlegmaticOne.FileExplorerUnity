using System.Threading;
using System.Threading.Tasks;
using PhlegmaticOne.FileExplorer.Features.FileEntries.ViewModels;

namespace PhlegmaticOne.FileExplorer.Features.Actions.Implementations.FileView.Implementations
{
    internal interface IFileTextLoader
    {
        Task<FileViewContent<string>> GetText(FileEntryViewModel file, CancellationToken token);
    }
}