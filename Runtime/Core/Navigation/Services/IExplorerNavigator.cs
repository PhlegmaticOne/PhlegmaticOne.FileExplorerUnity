using System.Collections.Generic;
using System.Threading;
using PhlegmaticOne.FileExplorer.Core.FileEntries.ViewModels;

namespace PhlegmaticOne.FileExplorer.Core.Navigation.Services
{
    internal interface IExplorerNavigator
    {
        IAsyncEnumerable<FileEntryViewModel> Navigate(
            string path, CancellationToken cancellationToken = default);
    }
}