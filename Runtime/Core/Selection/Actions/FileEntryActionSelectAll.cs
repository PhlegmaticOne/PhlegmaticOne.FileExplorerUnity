using System.Threading.Tasks;
using PhlegmaticOne.FileExplorer.Core.Actions.ViewModels;
using PhlegmaticOne.FileExplorer.Core.Selection.ViewModels;
using PhlegmaticOne.FileExplorer.Features.Actions;

namespace PhlegmaticOne.FileExplorer.Core.Selection.Actions
{
    internal sealed class FileEntryActionSelectAll : ExplorerAction
    {
        private readonly SelectionViewModel _selectionViewModel;

        public FileEntryActionSelectAll(
            SelectionViewModel selectionViewModel,
            ActionsViewModel actionsViewModel) : base(actionsViewModel)
        {
            _selectionViewModel = selectionViewModel;
        }

        public override string Description => "Select all";
        
        public override FileEntryActionColor Color => FileEntryActionColor.Auto;

        protected override Task<bool> ExecuteAction()
        {
            _selectionViewModel.SelectAll();
            return Task.FromResult(true);
        }
    }
}