using System;
using System.Threading.Tasks;
using PhlegmaticOne.FileExplorer.Features.FileEntries.ViewModels;

namespace PhlegmaticOne.FileExplorer.Features.FileEntries.Services.Actions.Handlers
{
    internal interface IFileEntryActionErrorHandler
    {
        Task HandleException(FileEntryViewModel fileEntry, Exception exception);
    }
}