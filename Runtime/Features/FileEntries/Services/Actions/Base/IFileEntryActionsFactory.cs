using System.Collections.Generic;
using PhlegmaticOne.FileExplorer.Features.Actions.Base;
using PhlegmaticOne.FileExplorer.Features.FileEntries.ViewModels;

namespace PhlegmaticOne.FileExplorer.Features.FileEntries.Services.Actions
{
    internal interface IFileEntryActionsFactory
    {
        FileEntryType EntryType { get; }
        IEnumerable<IExplorerAction> GetActions(FileEntryViewModel file);
    }
}