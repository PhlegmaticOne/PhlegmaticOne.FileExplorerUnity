using PhlegmaticOne.FileExplorer.Features.FileEntries.Entities;

namespace PhlegmaticOne.FileExplorer.Features.FileEntries.Core.Actions
{
    internal interface IFileEntryShowActionsProvider
    {
        void ShowActions(FileEntryViewModel file);
    }
}