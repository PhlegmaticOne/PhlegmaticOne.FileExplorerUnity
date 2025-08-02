using PhlegmaticOne.FileExplorer.Features.FileEntries.Entities.Direcrories;

namespace PhlegmaticOne.FileExplorer.Features.FileEntries.Entities.Files.Commands
{
    internal interface IDirectoryViewModelHoldClickCommand
    {
        void OnHoldClick(DirectoryViewModel directory);
    }
}