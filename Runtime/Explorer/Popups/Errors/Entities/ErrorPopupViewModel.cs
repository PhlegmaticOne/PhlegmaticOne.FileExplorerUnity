using System;
using PhlegmaticOne.FileExplorer.Infrastructure.Popups;
using PhlegmaticOne.FileExplorer.Infrastructure.ViewModels;

namespace PhlegmaticOne.FileExplorer.Popups.Errors
{
    internal sealed class ErrorPopupViewModel : PopupViewModel
    {
        public ErrorPopupViewModel(IPopupProvider popupProvider) : base(popupProvider)
        {
            Title = new ReactiveProperty<string>();
            Message = new ReactiveProperty<string>();
            ErrorName = new ReactiveProperty<string>();
        }

        public ErrorPopupViewModel SetTitle(string title)
        {
            Title.SetValueNotify(title);
            return this;
        }

        public ErrorPopupViewModel SetErrorFromException(Exception exception)
        {
            Message.SetValueNotify(exception.Message);
            ErrorName.SetValueNotify(exception.GetType().Name);
            return this;
        }
        
        public ReactiveProperty<string> Title { get; }
        public ReactiveProperty<string> Message { get; }
        public ReactiveProperty<string> ErrorName { get; }
    }
}