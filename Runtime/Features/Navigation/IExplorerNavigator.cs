using System.Collections.Generic;
using System.Threading;
using PhlegmaticOne.FileExplorer.Core.FileEntries.ViewModels;
using PhlegmaticOne.FileExplorer.Core.Navigation.ViewModels;

namespace PhlegmaticOne.FileExplorer.Features.Navigation
{
    internal interface IExplorerNavigator
    {
        IAsyncEnumerable<FileEntryViewModel> Navigate(
            NavigationViewModel navigationViewModel, CancellationToken cancellationToken = default);
    }
}