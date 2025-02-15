using System;
using System.Threading.Tasks;
using PhlegmaticOne.FileExplorer.Features.FileEntries.Entities;

namespace PhlegmaticOne.FileExplorer.Features.FileEntries.Core.Actions
{
    internal interface IFileEntryActionExecuteHandler
    {
        bool ProcessCanStartAction(FileEntryViewModel fileEntry);
        Task HandleException(FileEntryViewModel fileEntry, Exception exception);
    }
}