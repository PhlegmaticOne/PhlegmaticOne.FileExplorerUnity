using System.Threading.Tasks;
using PhlegmaticOne.FileExplorer.Infrastructure.ViewModels;

namespace PhlegmaticOne.FileExplorer.Features.Actions.ViewModels
{
    internal abstract class ActionViewModel : ViewModel
    {
        private readonly ActionsViewModel _actionsViewModel;

        protected ActionViewModel(ActionsViewModel actionsViewModel)
        {
            _actionsViewModel = actionsViewModel;
        }

        public abstract string Description { get; }
        public abstract ActionColor Color { get; }
        
        public Task<bool> Execute()
        {
            _actionsViewModel.Deactivate();
            return ExecuteAction();
        }

        protected abstract Task<bool> ExecuteAction();
    }
}