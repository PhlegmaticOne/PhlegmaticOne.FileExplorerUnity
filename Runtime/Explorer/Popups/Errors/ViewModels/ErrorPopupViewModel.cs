using System;
using PhlegmaticOne.FileExplorer.Features.FileEntries.ViewModels;
using PhlegmaticOne.FileExplorer.Infrastructure.Popups;

namespace PhlegmaticOne.FileExplorer.Popups.Errors
{
    internal sealed class ErrorPopupViewModel : PopupViewModel
    {
        private readonly FileEntryViewModel _fileEntry;
        private readonly Exception _exception;

        public ErrorPopupViewModel(FileEntryViewModel fileEntry, Exception exception)
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