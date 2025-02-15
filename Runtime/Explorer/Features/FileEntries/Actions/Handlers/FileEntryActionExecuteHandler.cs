using System;
using System.Threading.Tasks;
using PhlegmaticOne.FileExplorer.Features.FileEntries.ViewModels;

namespace PhlegmaticOne.FileExplorer.Features.FileEntries.Actions
{
    internal sealed class FileEntryActionExecuteHandler : IFileEntryActionExecuteHandler
    {
        private readonly IFileEntryActionStartHandler _startHandler;
        private readonly IFileEntryActionErrorHandler _errorHandler;

        public FileEntryActionExecuteHandler(
            IFileEntryActionStartHandler startHandler,
            IFileEntryActionErrorHandler errorHandler)
        {
            _startHandler = startHandler;
            _errorHandler = errorHandler;
        }
        
        public bool ProcessCanStartAction(FileEntryViewModel fileEntry)
        {
            return _startHandler.ProcessCanStartAction(fileEntry);
        }

        public Task HandleException(FileEntryViewModel fileEntry, Exception exception)
        {
            return _errorHandler.HandleException(fileEntry, exception);
        }
    }
}