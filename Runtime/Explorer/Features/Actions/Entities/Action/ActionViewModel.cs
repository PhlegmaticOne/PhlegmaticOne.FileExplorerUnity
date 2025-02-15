using PhlegmaticOne.FileExplorer.Features.Actions.Core;
using PhlegmaticOne.FileExplorer.Features.Actions.Entities.Actions;
using PhlegmaticOne.FileExplorer.Infrastructure.Extensions;
using PhlegmaticOne.FileExplorer.Infrastructure.ViewModels;
using PhlegmaticOne.FileExplorer.Infrastructure.ViewModels.Commands;
using PhlegmaticOne.FileExplorer.Services.Cancellation;

namespace PhlegmaticOne.FileExplorer.Features.Actions.Entities.Action
{
    internal sealed class ActionViewModel : ViewModel
    {
        private readonly IActionCommand _actionCommand;
        private readonly ActionsViewModel _actionsViewModel;
        private readonly IExplorerCancellationProvider _cancellationProvider;

        public ActionViewModel(string key,
            IActionCommand actionCommand,
            ActionsViewModel actionsViewModel,
            IExplorerCancellationProvider cancellationProvider)
        {
            Key = key;
            _actionCommand = actionCommand;
            _actionsViewModel = actionsViewModel;
            _cancellationProvider = cancellationProvider;
            ExecuteCommand = new CommandDelegateEmpty(ExecuteAction);
        }
        
        public string Key { get; }
        public ICommand ExecuteCommand { get; }
        
        private void ExecuteAction()
        {
            var token = _cancellationProvider.Token;
            _actionsViewModel.Deactivate();
            _actionCommand.Execute(token).ForgetUnawareCancellation();
        }
    }
}