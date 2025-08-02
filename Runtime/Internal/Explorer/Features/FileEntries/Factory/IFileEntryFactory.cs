using System.IO;
using PhlegmaticOne.FileExplorer.Features.FileEntries.Entities;

namespace PhlegmaticOne.FileExplorer.Features.FileEntries.Factory
{
    internal interface IFileEntryFactory
    {
        FileEntryViewModel CreateEntry(FileSystemInfo fileEntry);
    }
}