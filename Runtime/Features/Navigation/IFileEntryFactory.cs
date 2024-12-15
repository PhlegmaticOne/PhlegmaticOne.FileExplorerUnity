using System.IO;
using PhlegmaticOne.FileExplorer.Core.FileEntries.ViewModels;
using PhlegmaticOne.FileExplorer.Core.Navigation.ViewModels;

namespace PhlegmaticOne.FileExplorer.Features.Navigation
{
    internal interface IFileEntryFactory
    {
        FileEntryViewModel CreateEntry(FileSystemInfo fileEntry, NavigationViewModel navigationViewModel);
    }
}