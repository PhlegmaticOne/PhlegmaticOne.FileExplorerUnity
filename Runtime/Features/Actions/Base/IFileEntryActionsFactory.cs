using System.Collections.Generic;
using PhlegmaticOne.FileExplorer.Core.FileEntries.ViewModels;

namespace PhlegmaticOne.FileExplorer.Features.Actions
{
    internal interface IFileEntryActionsFactory
    {
        IEnumerable<IFileEntryAction> GetActions(FileEntryViewModel file);
    }
}