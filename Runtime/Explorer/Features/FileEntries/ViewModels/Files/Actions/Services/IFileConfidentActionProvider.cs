using PhlegmaticOne.FileExplorer.Features.FileEntries.Services.Actions;

namespace PhlegmaticOne.FileExplorer.Features.FileEntries.ViewModels.Files.Actions
{
    internal interface IFileConfidentActionProvider
    {
        bool TryGetConfidentAction(FileViewModel file, out FileEntryAction action);
    }
}