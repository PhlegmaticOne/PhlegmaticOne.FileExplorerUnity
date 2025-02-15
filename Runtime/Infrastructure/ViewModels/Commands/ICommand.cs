using System;

namespace PhlegmaticOne.FileExplorer.Infrastructure.ViewModels.Commands
{
    internal interface ICommand
    {
        event Action CanExecuteChanged;
        bool CanExecute();
        void Execute(object parameter);
        void RaiseCanExecuteChanged();
    }
}