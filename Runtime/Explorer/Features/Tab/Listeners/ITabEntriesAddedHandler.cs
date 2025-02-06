using System.Collections.Generic;
using PhlegmaticOne.FileExplorer.Features.FileEntries.ViewModels;

namespace PhlegmaticOne.FileExplorer.Features.Tab
{
    internal interface ITabEntriesAddedHandler
    {
        void HandleEntriesAdded(IEnumerable<FileEntryViewModel> fileEntries);
    }
}