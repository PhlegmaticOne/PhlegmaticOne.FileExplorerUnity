using System.Collections.Generic;
using PhlegmaticOne.FileExplorer.Core.FileEntries;
using PhlegmaticOne.FileExplorer.Core.FileEntries.ViewModels;

namespace PhlegmaticOne.FileExplorer.Features.Actions
{
    internal interface IFileEntryActionsFactory
    {
        FileEntryType EntryType { get; }
        IEnumerable<IExplorerAction> GetActions(FileEntryViewModel file);
    }
}