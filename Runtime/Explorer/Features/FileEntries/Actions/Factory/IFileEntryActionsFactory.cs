using PhlegmaticOne.FileExplorer.Features.Actions.ViewModels;
using PhlegmaticOne.FileExplorer.Features.FileEntries.ViewModels;

namespace PhlegmaticOne.FileExplorer.Features.FileEntries.Actions
{
    internal interface IFileEntryActionsFactory
    {
        ActionViewModel Create<T>(string key, FileEntryViewModel file) where T : class, IFileEntryAction;
    }
}