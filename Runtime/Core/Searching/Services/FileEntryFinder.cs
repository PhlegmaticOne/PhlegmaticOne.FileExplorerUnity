using System;
using PhlegmaticOne.FileExplorer.Core.FileEntries.ViewModels;

namespace PhlegmaticOne.FileExplorer.Core.Searching.Services
{
    internal sealed class FileEntryFinder : IFileEntryFinder
    {
        public bool Find(FileEntryViewModel fileEntry, string searchText)
        {
            return fileEntry.Name.Value.Contains(searchText, StringComparison.OrdinalIgnoreCase);
        }
    }
}