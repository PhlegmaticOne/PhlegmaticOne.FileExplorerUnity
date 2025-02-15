using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using PhlegmaticOne.FileExplorer.Features.Actions.Core;
using PhlegmaticOne.FileExplorer.Features.FileEntries.Entities;
using PhlegmaticOne.FileExplorer.Features.Searching.Entities;
using PhlegmaticOne.FileExplorer.Features.Selection.Entities;
using PhlegmaticOne.FileExplorer.Features.Tab.Entities;

namespace PhlegmaticOne.FileExplorer.Features.Selection.Actions
{
    internal sealed class ActionDeleteSelection : IAction
    {
        private readonly SelectionViewModel _selectionViewModel;
        private readonly TabViewModel _tabViewModel;
        private readonly SearchViewModel _searchViewModel;

        public ActionDeleteSelection(
            SelectionViewModel selectionViewModel,
            TabViewModel tabViewModel,
            SearchViewModel searchViewModel)
        {
            _selectionViewModel = selectionViewModel;
            _tabViewModel = tabViewModel;
            _searchViewModel = searchViewModel;
        }

        public Task Execute(CancellationToken token)
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