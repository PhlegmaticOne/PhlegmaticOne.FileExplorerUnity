using PhlegmaticOne.FileExplorer.Features.Actions.Services.Positioning;

namespace PhlegmaticOne.FileExplorer.Features.FileEntries.Entities.Files.Commands
{
    internal interface IFileViewModelClickCommand
    {
        void OnClick(FileViewModel file, ActionTargetViewPosition position);
    }
}