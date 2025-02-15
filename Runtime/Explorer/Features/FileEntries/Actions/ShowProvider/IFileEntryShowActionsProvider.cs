using PhlegmaticOne.FileExplorer.Features.FileEntries.ViewModels;

namespace PhlegmaticOne.FileExplorer.Features.FileEntries.Services.Actions
{
    internal interface IFileEntryShowActionsProvider
    {
        void ShowActions(FileEntryViewModel file);
    }
}