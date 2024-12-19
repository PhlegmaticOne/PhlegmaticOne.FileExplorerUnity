using System;
using System.Collections.Generic;
using PhlegmaticOne.FileExplorer.Core.FileEntries.ViewModels;
using PhlegmaticOne.FileExplorer.Core.Searching.ViewModels;
using PhlegmaticOne.FileExplorer.Core.Selection.Actions;
using PhlegmaticOne.FileExplorer.Core.Selection.ViewModels;
using PhlegmaticOne.FileExplorer.Features.Actions;
using PhlegmaticOne.FileExplorer.Infrastructure.DependencyInjection;

namespace PhlegmaticOne.FileExplorer.Core.Selection.Services
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
        
        public IEnumerable<IExplorerAction> GetActions(SelectionViewModel viewModel)
        {
            var result = new List<IExplorerAction>();

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

        private IEnumerable<IExplorerAction> GetSingleSelectionActions(FileEntryViewModel fileEntry)
        {
            var factory = Array.Find(_actionsFactories, x => x.EntryType == fileEntry.EntryType);
            return factory.GetActions(fileEntry);
        }
    }
}