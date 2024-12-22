using System.Threading.Tasks;
using PhlegmaticOne.FileExplorer.Core.Actions.ViewModels;

namespace PhlegmaticOne.FileExplorer.Features.Actions
{
    internal abstract class ExplorerAction : IExplorerAction
    {
        private readonly ActionsViewModel _actionsViewModel;

        protected ExplorerAction(ActionsViewModel actionsViewModel)
        {
            _actionsViewModel = actionsViewModel;
        }

        public abstract string Description { get; }
        public abstract FileEntryActionColor Color { get; }
        
        public Task<bool> Execute()
        {
            _actionsViewModel.Deactivate();
            return ExecuteAction();
        }

        protected abstract Task<bool> ExecuteAction();
    }
}