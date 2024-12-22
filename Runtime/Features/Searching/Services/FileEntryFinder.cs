using System;
using PhlegmaticOne.FileExplorer.Features.FileEntries.ViewModels;

namespace PhlegmaticOne.FileExplorer.Features.Searching.Services
{
    internal sealed class FileEntryFinder : IFileEntryFinder
    {
        public bool Find(FileEntryViewModel fileEntry, string searchText)
        {
            return fileEntry.Name.Value.Contains(searchText, StringComparison.OrdinalIgnoreCase);
        }
    }
}