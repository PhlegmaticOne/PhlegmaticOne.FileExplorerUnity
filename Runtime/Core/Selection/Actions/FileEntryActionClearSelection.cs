using System.Threading.Tasks;
using PhlegmaticOne.FileExplorer.Core.Actions.ViewModels;
using PhlegmaticOne.FileExplorer.Core.Selection.ViewModels;
using PhlegmaticOne.FileExplorer.Features.Actions;

namespace PhlegmaticOne.FileExplorer.Core.Selection.Actions
{
    internal sealed class FileEntryActionClearSelection : ExplorerAction
    {
        private readonly SelectionViewModel _selectionViewModel;

        public FileEntryActionClearSelection(
            SelectionViewModel selectionViewModel,
            FileEntryActionsViewModel actionsViewModel) : base(actionsViewModel)
        {
            _selectionViewModel = selectionViewModel;
        }

        public override string Description => "Deselect all";
        
        public override FileEntryActionColor Color => FileEntryActionColor.Auto;
        
        protected override Task<bool> ExecuteAction()
        {
            _selectionViewModel.ClearSelection();
            return Task.FromResult(true);
        }
    }
}