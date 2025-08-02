using PhlegmaticOne.FileExplorer.Features.Actions.Entities.Action;

namespace PhlegmaticOne.FileExplorer.Features.FileEntries.Entities.Files.Actions
{
    internal interface IFileConfidentActionProvider
    {
        bool TryGetConfidentAction(FileViewModel file, out ActionViewModel action);
    }
}