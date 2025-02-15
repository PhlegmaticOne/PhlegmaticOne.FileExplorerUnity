using System.Collections.Generic;
using System.Threading;
using PhlegmaticOne.FileExplorer.Features.FileEntries.Entities;

namespace PhlegmaticOne.FileExplorer.Features.Navigation.Services.Navigator
{
    internal interface IExplorerNavigator
    {
        IAsyncEnumerable<FileEntryViewModel> Navigate(string path, CancellationToken cancellationToken);
    }
}