using PhlegmaticOne.FileExplorer.Core.FileEntries.ViewModels;

namespace PhlegmaticOne.FileExplorer.Features.Actions
{
    internal interface IFileEntryActionsProvider
    {
        void ShowActions(FileEntryViewModel file);
    }
}