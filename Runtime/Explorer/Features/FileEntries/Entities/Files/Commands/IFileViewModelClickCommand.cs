using PhlegmaticOne.FileExplorer.Features.FileEntries.Core.Models;

namespace PhlegmaticOne.FileExplorer.Features.FileEntries.Entities.Files.Commands
{
    internal interface IFileViewModelClickCommand
    {
        void OnClick(FileViewModel file, FileEntryPosition position);
    }
}