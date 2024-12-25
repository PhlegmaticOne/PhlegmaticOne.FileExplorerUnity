using PhlegmaticOne.FileExplorer.Features.FileEntries.ViewModels;

namespace PhlegmaticOne.FileExplorer.Features.Searching.Services
{
    internal interface IFileEntrySearchFilter
    {
        bool IsFit(FileEntryViewModel fileEntry, string searchText);
    }
}