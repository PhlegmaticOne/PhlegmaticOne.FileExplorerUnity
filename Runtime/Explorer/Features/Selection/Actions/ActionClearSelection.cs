using System.Threading;
using System.Threading.Tasks;
using PhlegmaticOne.FileExplorer.Features.Actions.ViewModels;
using PhlegmaticOne.FileExplorer.Features.Selection.ViewModels;
using PhlegmaticOne.FileExplorer.Services.Cancellation;

namespace PhlegmaticOne.FileExplorer.Features.Selection.Actions
{
    internal sealed class ActionClearSelection : ActionViewModel
    {
        private readonly SelectionViewModel _selectionViewModel;

        public ActionClearSelection(
            SelectionViewModel selectionViewModel,
            IExplorerCancellationProvider cancellationProvider,
            ActionsViewModel actionsViewModel) : base(actionsViewModel, cancellationProvider)
        {
            _selectionViewModel = selectionViewModel;
        }

        public override string Description => "Deselect all";
        
        public override ActionColor Color => ActionColor.Auto;
        
        protected override Task ExecuteAction(CancellationToken token)
        {
            _selectionViewModel.Clear();
            return Task.CompletedTask;
        }
    }
}