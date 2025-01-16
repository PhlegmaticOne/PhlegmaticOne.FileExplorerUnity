using PhlegmaticOne.FileExplorer.Features.FileEntries.ViewModels;

namespace PhlegmaticOne.FileExplorer.Features.FileEntries.Services.Actions.Handlers
{
    internal interface IFileEntryActionStartHandler
    {
        bool ProcessCanStartAction(FileEntryViewModel fileEntry);
    }
}