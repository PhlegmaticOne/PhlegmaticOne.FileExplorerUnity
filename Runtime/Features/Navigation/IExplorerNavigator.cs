using System.Collections.Generic;
using PhlegmaticOne.FileExplorer.Core.FileEntries.ViewModels;

namespace PhlegmaticOne.FileExplorer.Features.Navigation
{
    internal interface IExplorerNavigator
    {
        IAsyncEnumerable<FileEntryViewModel> Navigate(string path);
    }
}