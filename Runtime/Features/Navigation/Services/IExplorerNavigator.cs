using System.Collections.Generic;
using System.Threading;
using PhlegmaticOne.FileExplorer.Features.FileEntries.ViewModels;

namespace PhlegmaticOne.FileExplorer.Features.Navigation.Services
{
    internal interface IExplorerNavigator
    {
        IAsyncEnumerable<FileEntryViewModel> Navigate(
            string path, CancellationToken cancellationToken = default);
    }
}