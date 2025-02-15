using PhlegmaticOne.FileExplorer.Features.Actions.Entities.Action;
using PhlegmaticOne.FileExplorer.Features.FileEntries.Entities;

namespace PhlegmaticOne.FileExplorer.Features.FileEntries.Core.Actions
{
    internal interface IFileEntryActionsFactory
    {
        ActionViewModel Create<T>(string key, FileEntryViewModel file) where T : class, IFileEntryAction;
    }
}