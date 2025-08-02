using System;
using System.Threading.Tasks;
using PhlegmaticOne.FileExplorer.Features.FileEntries.Entities;

namespace PhlegmaticOne.FileExplorer.Features.FileEntries.Actions.Core
{
    internal interface IFileEntryActionErrorHandler
    {
        Task HandleException(FileEntryViewModel fileEntry, Exception exception);
    }
}