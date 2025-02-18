using PhlegmaticOne.FileExplorer.Features.FileEntries.Entities;

namespace PhlegmaticOne.FileExplorer.Features.FileEntries.Actions.Core
{
    internal interface IFileEntryActionStartHandler
    {
        bool ProcessCanStartAction(FileEntryViewModel fileEntry);
    }
}