using System;
using PhlegmaticOne.FileExplorer.Features.FileEntries.Entities;
using PhlegmaticOne.FileExplorer.Infrastructure.Popups;
using PhlegmaticOne.FileExplorer.Infrastructure.ViewModels;

namespace PhlegmaticOne.FileExplorer.Popups.Errors
{
    internal sealed class ErrorPopupViewModel : PopupViewModel
    {
        private readonly FileEntryViewModel _fileEntry;
        private readonly Exception _exception;

        public ErrorPopupViewModel(string title, string message, string errorName)
        {
            Title = new ReactiveProperty<string>(title);
            Message = new ReactiveProperty<string>(message);
            ErrorName = new ReactiveProperty<string>(errorName);
        }

        public static ErrorPopupViewModel FromFileError(FileEntryViewModel fileEntry, Exception exception)
        {
            return new ErrorPopupViewModel(
                title: $"{fileEntry.Name} ({fileEntry.EntryType})",
                message: exception.Message,
                errorName: exception.GetType().Name);
        }

        public static ErrorPopupViewModel FromException(Exception exception)
        {
            return new ErrorPopupViewModel(
                title: "Exception occured",
                message: exception.Message,
                errorName: exception.GetType().Name); 
        }
        
        public ReactiveProperty<string> Title { get; }
        public ReactiveProperty<string> Message { get; }
        public ReactiveProperty<string> ErrorName { get; }
    }
}