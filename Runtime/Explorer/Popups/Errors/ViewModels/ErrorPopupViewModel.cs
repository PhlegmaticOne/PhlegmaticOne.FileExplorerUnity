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

        public ErrorPopupViewModel(IPopupProvider popupProvider) : base(popupProvider)
        {
            Title = new ReactiveProperty<string>();
            Message = new ReactiveProperty<string>();
            ErrorName = new ReactiveProperty<string>();
        }

        public void Setup(string title, string message, string errorName)
        {
            Title.SetValueNotify(title);
            Message.SetValueNotify(message);
            ErrorName.SetValueNotify(errorName);
        }
        
        public ReactiveProperty<string> Title { get; }
        public ReactiveProperty<string> Message { get; }
        public ReactiveProperty<string> ErrorName { get; }
    }
}