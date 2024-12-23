using System;
using System.Threading.Tasks;
using PhlegmaticOne.FileExplorer.Features.FileEntries.ViewModels;

namespace PhlegmaticOne.FileExplorer.Features.FileEntries.Services.Actions.Handlers.Popups
{
    internal interface IFileEntryActionErrorViewProvider
    {
        Task ViewError(FileEntryViewModel fileEntry, Exception exception);
    }
}