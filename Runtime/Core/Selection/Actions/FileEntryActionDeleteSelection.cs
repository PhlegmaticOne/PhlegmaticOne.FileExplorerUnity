using System.Threading.Tasks;
using PhlegmaticOne.FileExplorer.Core.Actions.ViewModels;
using PhlegmaticOne.FileExplorer.Core.Searching.ViewModels;
using PhlegmaticOne.FileExplorer.Core.Selection.ViewModels;
using PhlegmaticOne.FileExplorer.Core.Tab.ViewModels;
using PhlegmaticOne.FileExplorer.Features.Actions;

namespace PhlegmaticOne.FileExplorer.Core.Selection.Actions
{
    internal sealed class FileEntryActionDeleteSelection : ExplorerAction
    {
        private readonly SelectionViewModel _selectionViewModel;
        private readonly TabViewModel _tabViewModel;
        private readonly SearchViewModel _searchViewModel;

        public FileEntryActionDeleteSelection(
            SelectionViewModel selectionViewModel,
            TabViewModel tabViewModel,
            FileEntryActionsViewModel actionsViewModel,
            SearchViewModel searchViewModel) : base(actionsViewModel)
        {
            _selectionViewModel = selectionViewModel;
            _tabViewModel = tabViewModel;
            _searchViewModel = searchViewModel;
        }

        public override string Description => "Delete all";
        
        public override FileEntryActionColor Color => FileEntryActionColor.WithTextColor(UnityEngine.Color.red);
        
        protected override Task<bool> ExecuteAction()
        {
            var selection = _selectionViewModel.GetSelection();
            
            foreach (var fileEntry in selection)
            {
                fileEntry.Delete();
            }
            
            _tabViewModel.RemoveRange(selection);
            _selectionViewModel.ClearSelection();
            _searchViewModel.Research();
            return Task.FromResult(true);
        }
    }
}