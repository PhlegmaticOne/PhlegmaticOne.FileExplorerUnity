using PhlegmaticOne.FileExplorer.Features.FileEntries.Entities;

namespace PhlegmaticOne.FileExplorer.Features.Searching.Services.Filters
{
    internal interface IFileEntrySearchFilter
    {
        bool IsFit(FileEntryViewModel fileEntry, string searchText);
    }
}