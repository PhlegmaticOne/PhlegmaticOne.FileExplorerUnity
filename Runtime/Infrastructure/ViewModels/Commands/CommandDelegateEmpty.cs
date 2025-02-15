using System;

namespace PhlegmaticOne.FileExplorer.Infrastructure.ViewModels.Commands
{
    internal sealed class CommandDelegateEmpty : ICommand
    {
        private readonly Action _executeAction;
        private readonly Func<bool> _canExecute;

        public CommandDelegateEmpty(Action executeAction, Func<bool> canExecute = null)
        {
            _executeAction = executeAction;
            _canExecute = canExecute;
        }
        
        public event Action CanExecuteChanged;
        public bool CanExecute()
        {
            return _canExecute?.Invoke() ?? true;
        }

        public void Execute(object parameter)
        {
            _executeAction.Invoke();
        }

        public void RaiseCanExecuteChanged()
        {
            CanExecuteChanged?.Invoke();
        }
    }
}