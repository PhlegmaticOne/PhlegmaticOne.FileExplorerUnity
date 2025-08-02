using PhlegmaticOne.FileExplorer.Features.Actions.Services.Positioning;
using PhlegmaticOne.FileExplorer.Features.FileEntries.Entities.Direcrories;

namespace PhlegmaticOne.FileExplorer.Features.FileEntries.Entities.Files.Commands
{
    internal interface IDirectoryViewModelClickCommand
    {
        void OnClick(DirectoryViewModel directory, ActionTargetViewPosition position);
    }
}