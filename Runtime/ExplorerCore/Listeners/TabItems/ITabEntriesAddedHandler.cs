﻿using System.Collections.Generic;
using PhlegmaticOne.FileExplorer.Features.FileEntries.ViewModels;

namespace PhlegmaticOne.FileExplorer.ExplorerCore.Listeners.TabItems
{
    internal interface ITabEntriesAddedHandler
    {
        void HandleEntriesAdded(IEnumerable<FileEntryViewModel> fileEntries);
    }
}