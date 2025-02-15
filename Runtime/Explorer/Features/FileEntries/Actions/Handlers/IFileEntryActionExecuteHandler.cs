using System;
using System.Threading.Tasks;
using PhlegmaticOne.FileExplorer.Features.FileEntries.ViewModels;

namespace PhlegmaticOne.FileExplorer.Features.FileEntries.Actions
{
    internal interface IFileEntryActionExecuteHandler
    {
        bool ProcessCanStartAction(FileEntryViewModel fileEntry);
        Task HandleException(FileEntryViewModel fileEntry, Exception exception);
    }
}