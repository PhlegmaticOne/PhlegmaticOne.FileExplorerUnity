using System.IO;
using PhlegmaticOne.FileExplorer.Core.FileEntries.ViewModels;

namespace PhlegmaticOne.FileExplorer.Core.FileEntries.Factory
{
    internal interface IFileEntryFactory
    {
        FileEntryViewModel CreateEntry(FileSystemInfo fileEntry);
    }
}