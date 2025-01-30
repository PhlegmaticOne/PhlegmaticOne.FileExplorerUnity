using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using PhlegmaticOne.FileExplorer.Features.Actions.ViewModels;
using PhlegmaticOne.FileExplorer.Features.FileEntries.ViewModels;
using PhlegmaticOne.FileExplorer.Features.Searching.ViewModels;
using PhlegmaticOne.FileExplorer.Features.Selection.ViewModels;
using PhlegmaticOne.FileExplorer.Features.Tab.ViewModels;
using PhlegmaticOne.FileExplorer.Services.Cancellation;

namespace PhlegmaticOne.FileExplorer.Features.Selection.Actions
{
    internal sealed class ActionDeleteSelection : ActionViewModel
    {
        private readonly SelectionViewModel _selectionViewModel;
        private readonly TabViewModel _tabViewModel;
        private readonly SearchViewModel _searchViewModel;

        public ActionDeleteSelection(
            SelectionViewModel selectionViewModel,
            TabViewModel tabViewModel,
            ActionsViewModel actionsViewModel,
            IExplorerCancellationProvider cancellationProvider,
            SearchViewModel searchViewModel) : base(actionsViewModel, cancellationProvider)
        {
            _selectionViewModel = selectionViewModel;
            _tabViewModel = tabViewModel;
            _searchViewModel = searchViewModel;
        }

        public override string Description => "Delete all";
        
        public override ActionColor Color => ActionColor.WithTextColor(UnityEngine.Color.red);
        
        protected override Task ExecuteAction(CancellationToken token)
        {
            var selection = _selectionViewModel.GetSelection();
            DeleteSelectedEntries(selection);
            RemoveEntriesFromTab(selection);
            _selectionViewModel.Clear();
            _searchViewModel.Research();
            return Task.CompletedTask;
        }

        private void RemoveEntriesFromTab(IEnumerable<FileEntryViewModel> selection)
        {
            if (_selectionViewModel.IsAllSelected)
            {
                _tabViewModel.Clear();
            }
            else
            {
                _tabViewModel.RemoveRange(selection);
            }
        }

        private static void DeleteSelectedEntries(IEnumerable<FileEntryViewModel> selection)
        {
            foreach (var fileEntry in selection)
            {
                fileEntry.Delete();
            }
        }
    }
}