using PhlegmaticOne.FileExplorer.Features.Actions.ViewModels;

namespace PhlegmaticOne.FileExplorer.Features.FileEntries.ViewModels.Files.Actions
{
    internal interface IFileConfidentActionProvider
    {
        bool TryGetConfidentAction(FileViewModel file, out ActionViewModel action);
    }
}