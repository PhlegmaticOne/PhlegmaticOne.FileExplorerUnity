using PhlegmaticOne.FileExplorer.Core.FileEntries.ViewModels;

namespace PhlegmaticOne.FileExplorer.Core.Searching.Services
{
    internal interface IFileEntryFinder
    {
        bool Find(FileEntryViewModel fileEntry, string searchText);
    }
}