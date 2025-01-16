using System.Threading.Tasks;
using PhlegmaticOne.FileExplorer.Features.Actions.ViewModels;
using PhlegmaticOne.FileExplorer.Features.Selection.ViewModels;

namespace PhlegmaticOne.FileExplorer.Features.Selection.Actions
{
    internal sealed class ActionSelectAll : ActionViewModel
    {
        private readonly SelectionViewModel _selectionViewModel;

        public ActionSelectAll(
            SelectionViewModel selectionViewModel,
            ActionsViewModel actionsViewModel) : base(actionsViewModel)
        {
            _selectionViewModel = selectionViewModel;
        }

        public override string Description => "Select all";
        
        public override ActionColor Color => ActionColor.Auto;

        protected override Task<bool> ExecuteAction()
        {
            _selectionViewModel.SelectAll();
            return Task.FromResult(true);
        }
    }
}