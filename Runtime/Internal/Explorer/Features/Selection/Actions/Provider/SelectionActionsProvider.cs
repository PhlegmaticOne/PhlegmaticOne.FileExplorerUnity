using System;
using System.Collections.Generic;
using PhlegmaticOne.FileExplorer.Features.Actions.Core;
using PhlegmaticOne.FileExplorer.Features.Actions.Entities.Action;
using PhlegmaticOne.FileExplorer.Features.FileEntries.Actions.Core;
using PhlegmaticOne.FileExplorer.Features.FileEntries.Entities;
using PhlegmaticOne.FileExplorer.Features.Searching.Entities;
using PhlegmaticOne.FileExplorer.Features.Selection.Entities;

namespace PhlegmaticOne.FileExplorer.Features.Selection.Actions
{
    internal sealed class SelectionActionsProvider : ISelectionActionsProvider
    {
        private readonly IActionViewModelFactory _factory;
        private readonly IFileEntryShowActionsFactory[] _actionsFactories;
        private readonly SearchViewModel _searchViewModel;

        public SelectionActionsProvider(
            IActionViewModelFactory factory,
            IFileEntryShowActionsFactory[] actionsFactories,
            SearchViewModel searchViewModel)
        {
            _factory = factory;
            _actionsFactories = actionsFactories;
            _searchViewModel = searchViewModel;
        }
        
        public IEnumerable<ActionViewModel> GetActions(SelectionViewModel viewModel)
        {
            var result = new List<ActionViewModel>();

            if (!viewModel.IsAllSelected && _searchViewModel.FoundEntriesCount != 0)
            {
                result.Add(_factory.SelectAll());
            }

            if (viewModel.IsAnySelected())
            {
                result.Add(_factory.ClearSelection());
            }

            if (viewModel.TryGetSingleSelection(out var fileEntry))
            {
                result.AddRange(GetSingleSelectionActions(fileEntry));
            }
            else if (viewModel.IsAnySelected())
            {
                result.Add(_factory.SelectionProperties());
                result.Add(_factory.DeleteSelection());
            }

            return result;
        }

        private IEnumerable<ActionViewModel> GetSingleSelectionActions(FileEntryViewModel fileEntry)
        {
            var factory = Array.Find(_actionsFactories, x => x.EntryType == fileEntry.EntryType);
            return factory.GetActions(fileEntry);
        }
    }
}