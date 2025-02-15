using System.Collections.Generic;
using PhlegmaticOne.FileExplorer.Features.FileEntries.Entities;

namespace PhlegmaticOne.FileExplorer.Features.Tab.Listeners
{
    internal interface ITabEntriesAddedHandler
    {
        void HandleEntriesAdded(IEnumerable<FileEntryViewModel> fileEntries);
    }
}