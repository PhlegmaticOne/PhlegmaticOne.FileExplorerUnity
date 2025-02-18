using System.Collections.Generic;
using PhlegmaticOne.FileExplorer.Features.Actions.Entities.Action;
using PhlegmaticOne.FileExplorer.Features.FileEntries.Core.Models;
using PhlegmaticOne.FileExplorer.Features.FileEntries.Entities;

namespace PhlegmaticOne.FileExplorer.Features.FileEntries.Actions.Core
{
    internal interface IFileEntryShowActionsFactory
    {
        FileEntryType EntryType { get; }
        IEnumerable<ActionViewModel> GetActions(FileEntryViewModel file);
    }
}