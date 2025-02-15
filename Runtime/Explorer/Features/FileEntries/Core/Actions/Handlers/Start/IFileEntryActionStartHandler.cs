using PhlegmaticOne.FileExplorer.Features.FileEntries.Entities;

namespace PhlegmaticOne.FileExplorer.Features.FileEntries.Core.Actions
{
    internal interface IFileEntryActionStartHandler
    {
        bool ProcessCanStartAction(FileEntryViewModel fileEntry);
    }
}