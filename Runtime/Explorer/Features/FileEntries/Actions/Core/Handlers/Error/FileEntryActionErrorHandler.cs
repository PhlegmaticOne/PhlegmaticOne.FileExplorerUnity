using System;
using System.Threading.Tasks;
using PhlegmaticOne.FileExplorer.Features.FileEntries.Entities;
using PhlegmaticOne.FileExplorer.Popups.Errors;

namespace PhlegmaticOne.FileExplorer.Features.FileEntries.Actions.Core
{
    internal sealed class FileEntryActionErrorHandler : IFileEntryActionErrorHandler
    {
        private readonly IErrorPopupProvider _errorPopupProvider;

        public FileEntryActionErrorHandler(IErrorPopupProvider errorPopupProvider)
        {
            _errorPopupProvider = errorPopupProvider;
        }
        
        public Task HandleException(FileEntryViewModel fileEntry, Exception exception)
        {
            return _errorPopupProvider.ViewError(fileEntry, exception);
        }
    }
}