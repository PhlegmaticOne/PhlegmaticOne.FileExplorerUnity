using System.Threading.Tasks;
using PhlegmaticOne.FileExplorer.Features.Actions.Base;
using PhlegmaticOne.FileExplorer.Features.Actions.ViewModels;
using PhlegmaticOne.FileExplorer.Features.Selection.ViewModels;

namespace PhlegmaticOne.FileExplorer.Features.Selection.Actions
{
    internal sealed class FileEntryActionClearSelection : ExplorerAction
    {
        private readonly SelectionViewModel _selectionViewModel;

        public FileEntryActionClearSelection(
            SelectionViewModel selectionViewModel,
            ActionsViewModel actionsViewModel) : base(actionsViewModel)
        {
            _selectionViewModel = selectionViewModel;
        }

        public override string Description => "Deselect all";
        
        public override ExplorerActionColor Color => ExplorerActionColor.Auto;
        
        protected override Task<bool> ExecuteAction()
        {
            _selectionViewModel.Clear();
            return Task.FromResult(true);
        }
    }
}