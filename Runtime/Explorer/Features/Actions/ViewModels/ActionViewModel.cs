using System.Threading;
using System.Threading.Tasks;
using PhlegmaticOne.FileExplorer.Infrastructure.Extensions;
using PhlegmaticOne.FileExplorer.Infrastructure.ViewModels;
using PhlegmaticOne.FileExplorer.Infrastructure.ViewModels.Commands;
using PhlegmaticOne.FileExplorer.Services.Cancellation;

namespace PhlegmaticOne.FileExplorer.Features.Actions.ViewModels
{
    internal abstract class ActionViewModel : ViewModel
    {
        private readonly ActionsViewModel _actionsViewModel;
        private readonly IExplorerCancellationProvider _cancellationProvider;

        protected ActionViewModel(string key,
            ActionsViewModel actionsViewModel,
            IExplorerCancellationProvider cancellationProvider)
        {
            Key = key;
            _actionsViewModel = actionsViewModel;
            _cancellationProvider = cancellationProvider;
            ExecuteCommand = new CommandDelegateEmpty(ExecuteAction);
        }
        
        public string Key { get; }
        public ICommand ExecuteCommand { get; }
        
        private void ExecuteAction()
        {
            _actionsViewModel.Deactivate();
            ExecuteAction(_cancellationProvider.Token).ForgetUnawareCancellation();
        }

        protected abstract Task ExecuteAction(CancellationToken token);
    }
}