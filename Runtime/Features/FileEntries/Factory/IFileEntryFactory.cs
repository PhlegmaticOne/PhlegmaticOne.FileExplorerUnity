using System.IO;
using PhlegmaticOne.FileExplorer.Features.FileEntries.ViewModels;

namespace PhlegmaticOne.FileExplorer.Features.FileEntries.Factory
{
    internal interface IFileEntryFactory
    {
        FileEntryViewModel CreateEntry(FileSystemInfo fileEntry);
    }
}