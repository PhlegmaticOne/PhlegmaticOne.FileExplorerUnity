using PhlegmaticOne.FileExplorer.Features.FileEntries.ViewModels;

namespace PhlegmaticOne.FileExplorer.Features.Searching.Services
{
    internal interface IFileEntryFinder
    {
        bool Find(FileEntryViewModel fileEntry, string searchText);
    }
}