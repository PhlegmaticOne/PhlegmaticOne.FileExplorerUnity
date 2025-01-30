using System.Threading;
using System.Threading.Tasks;
using PhlegmaticOne.FileExplorer.Infrastructure.ViewModels;
using PhlegmaticOne.FileExplorer.Services.Cancellation;

namespace PhlegmaticOne.FileExplorer.Features.Actions.ViewModels
{
    internal abstract class ActionViewModel : ViewModel
    {
        private readonly ActionsViewModel _actionsViewModel;
        private readonly IExplorerCancellationProvider _cancellationProvider;

        protected ActionViewModel(
            ActionsViewModel actionsViewModel,
            IExplorerCancellationProvider cancellationProvider)
        {
            _actionsViewModel = actionsViewModel;
            _cancellationProvider = cancellationProvider;
        }

        public abstract string Description { get; }
        public abstract ActionColor Color { get; }
        
        public Task Execute()
        {
            _actionsViewModel.Deactivate();
            return ExecuteAction(_cancellationProvider.Token);
        }

        protected abstract Task ExecuteAction(CancellationToken token);
    }
}