using System;
using System.Threading.Tasks;
using PhlegmaticOne.FileExplorer.Features.FileEntries.Services.Actions.Handlers.Popups;
using PhlegmaticOne.FileExplorer.Features.FileEntries.ViewModels;

namespace PhlegmaticOne.FileExplorer.Features.FileEntries.Services.Actions.Handlers
{
    internal sealed class FileEntryActionErrorHandler : IFileEntryActionErrorHandler
    {
        private readonly IFileEntryActionErrorViewProvider _errorViewProvider;

        public FileEntryActionErrorHandler(IFileEntryActionErrorViewProvider errorViewProvider)
        {
            _errorViewProvider = errorViewProvider;
        }
        
        public Task HandleException(FileEntryViewModel fileEntry, Exception exception)
        {
            return _errorViewProvider.ViewError(fileEntry, exception);
        }
    }
}