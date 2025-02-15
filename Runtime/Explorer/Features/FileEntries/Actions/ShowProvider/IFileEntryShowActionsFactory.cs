using System.Collections.Generic;
using PhlegmaticOne.FileExplorer.Features.Actions.ViewModels;
using PhlegmaticOne.FileExplorer.Features.FileEntries.ViewModels;

namespace PhlegmaticOne.FileExplorer.Features.FileEntries.Services.Actions
{
    internal interface IFileEntryShowActionsFactory
    {
        FileEntryType EntryType { get; }
        IEnumerable<ActionViewModel> GetActions(FileEntryViewModel file);
    }
}