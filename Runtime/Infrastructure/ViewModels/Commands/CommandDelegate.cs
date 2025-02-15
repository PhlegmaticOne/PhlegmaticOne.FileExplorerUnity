using System;

namespace PhlegmaticOne.FileExplorer.Infrastructure.ViewModels.Commands
{
    internal class CommandDelegate<T> : ICommand
    {
        private readonly Action<T> _executeAction;
        private readonly Func<bool> _canExecuteAction;

        protected CommandDelegate(Action<T> executeAction, Func<bool> canExecuteAction = null)
        {
            _executeAction = executeAction;
            _canExecuteAction = canExecuteAction;
        }
        
        public event Action CanExecuteChanged;
        
        public bool CanExecute()
        {
            return _canExecuteAction?.Invoke() ?? true;
        }

        public void Execute(object parameter)
        {
            if (parameter is T generic)
            {
                _executeAction.Invoke(generic);
            }
        }

        public void RaiseCanExecuteChanged()
        {
            CanExecuteChanged?.Invoke();
        }
    }
}