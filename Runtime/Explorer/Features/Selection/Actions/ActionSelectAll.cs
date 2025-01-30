using System.Threading;
using System.Threading.Tasks;
using PhlegmaticOne.FileExplorer.Features.Actions.ViewModels;
using PhlegmaticOne.FileExplorer.Features.Selection.ViewModels;
using PhlegmaticOne.FileExplorer.Services.Cancellation;

namespace PhlegmaticOne.FileExplorer.Features.Selection.Actions
{
    internal sealed class ActionSelectAll : ActionViewModel
    {
        private readonly SelectionViewModel _selectionViewModel;

        public ActionSelectAll(
            SelectionViewModel selectionViewModel,
            IExplorerCancellationProvider cancellationProvider,
            ActionsViewModel actionsViewModel) : base(actionsViewModel, cancellationProvider)
        {
            _selectionViewModel = selectionViewModel;
        }

        public override string Description => "Select all";
        
        public override ActionColor Color => ActionColor.Auto;

        protected override Task ExecuteAction(CancellationToken token)
        {
            _selectionViewModel.SelectAll();
            return Task.CompletedTask;
        }
    }
}