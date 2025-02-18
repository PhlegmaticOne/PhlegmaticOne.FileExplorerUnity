using System.Threading;
using System.Threading.Tasks;
using PhlegmaticOne.FileExplorer.Features.FileEntries.Entities;

namespace PhlegmaticOne.FileExplorer.Services.ContentLoading
{
    internal interface IFileTextLoader
    {
        Task<FileViewContent<string>> GetText(FileEntryViewModel file, CancellationToken token);
    }
}