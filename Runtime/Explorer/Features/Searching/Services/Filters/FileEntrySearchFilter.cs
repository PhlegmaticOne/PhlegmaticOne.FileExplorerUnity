using System;
using PhlegmaticOne.FileExplorer.Features.FileEntries.Entities;

namespace PhlegmaticOne.FileExplorer.Features.Searching.Services.Filters
{
    internal sealed class FileEntrySearchFilter : IFileEntrySearchFilter
    {
        public bool IsFit(FileEntryViewModel fileEntry, string searchText)
        {
            return fileEntry.Name.Value.Contains(searchText, StringComparison.OrdinalIgnoreCase);
        }
    }
}