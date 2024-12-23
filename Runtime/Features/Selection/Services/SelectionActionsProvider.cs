using System;
using System.Collections.Generic;
using PhlegmaticOne.FileExplorer.Features.Actions.ViewModels;
using PhlegmaticOne.FileExplorer.Features.FileEntries.Services.Actions;
using PhlegmaticOne.FileExplorer.Features.FileEntries.ViewModels;
using PhlegmaticOne.FileExplorer.Features.Searching.ViewModels;
using PhlegmaticOne.FileExplorer.Features.Selection.Actions;
using PhlegmaticOne.FileExplorer.Features.Selection.ViewModels;
using PhlegmaticOne.FileExplorer.Infrastructure.DependencyInjection;

namespace PhlegmaticOne.FileExplorer.Features.Selection.Services
{
    internal sealed class SelectionActionsProvider : ISelectionActionsProvider
    {
        private readonly IDependencyContainer _container;
        private readonly IFileEntryActionsFactory[] _actionsFactories;
        private readonly SearchViewModel _searchViewModel;

        public SelectionActionsProvider(
            IDependencyContainer container,
            IFileEntryActionsFactory[] actionsFactories,
            SearchViewModel searchViewModel)
        {
            _container = container;
            _actionsFactories = actionsFactories;
            _searchViewModel = searchViewModel;
        }
        
        public IEnumerable<ActionViewModel> GetActions(SelectionViewModel viewModel)
        {
            var result = new List<ActionViewModel>();

            if (!viewModel.IsAllSelected && _searchViewModel.FoundEntriesCount != 0)
            {
                result.Add(_container.Instantiate<FileEntryActionSelectAll>());
            }

            if (viewModel.IsAnySelected())
            {
                result.Add(_container.Instantiate<FileEntryActionClearSelection>());
            }

            if (viewModel.TryGetSingleSelection(out var fileEntry))
            {
                result.AddRange(GetSingleSelectionActions(fileEntry));
            }
            else if(viewModel.IsAnySelected())
            {
                result.Add(_container.Instantiate<FileEntryActionSelectionProperties>());
                result.Add(_container.Instantiate<FileEntryActionDeleteSelection>());
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