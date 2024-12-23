using System;
using PhlegmaticOne.FileExplorer.Features.FileEntries.ViewModels;
using PhlegmaticOne.FileExplorer.Infrastructure.Popups;

namespace PhlegmaticOne.FileExplorer.Features.FileEntries.Services.Actions.Handlers.Popups
{
    internal sealed class FileEntryActionErrorPopupViewModel : PopupViewModel
    {
        private readonly FileEntryViewModel _fileEntry;
        private readonly Exception _exception;

        public FileEntryActionErrorPopupViewModel(FileEntryViewModel fileEntry, Exception exception)
        {
            _fileEntry = fileEntry;
            _exception = exception;
        }

        public string GetFileDescription()
        {
            return $"{_fileEntry.Name} ({_fileEntry.EntryType})";
        }

        public string GetErrorMessage()
        {
            return _exception.Message;
        }

        public string GetErrorName()
        {
            return _exception.GetType().Name;
        }
    }
}