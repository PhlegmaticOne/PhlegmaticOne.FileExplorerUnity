using System.Collections.Generic;
using System.Linq;
using PhlegmaticOne.FileExplorer.Core.FileEntries;
using PhlegmaticOne.FileExplorer.Core.FileEntries.ViewModels;
using PhlegmaticOne.FileExplorer.Core.FileEntries.ViewModels.Directories;
using PhlegmaticOne.FileExplorer.Core.FileEntries.ViewModels.Files;
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
        private readonly FileEntryActionsFactoryFile _fileActionsFactory;
        private readonly FileEntryActionsFactoryDirectory _directoryActionsFactory;
        private readonly SearchViewModel _searchViewModel;

        public SelectionActionsProvider(
            IDependencyContainer container,
            FileEntryActionsFactoryFile fileActionsFactory,
            FileEntryActionsFactoryDirectory directoryActionsFactory,
            SearchViewModel searchViewModel)
        {
            _container = container;
            _fileActionsFactory = fileActionsFactory;
            _directoryActionsFactory = directoryActionsFactory;
            _searchViewModel = searchViewModel;
        }
        
        public IEnumerable<IFileEntryAction> GetActions(SelectionViewModel viewModel)
        {
            var result = new List<IFileEntryAction>();

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

        private IEnumerable<IFileEntryAction> GetSingleSelectionActions(FileEntryViewModel fileEntry)
        {
            return fileEntry.EntryType switch
            {
                FileEntryType.File => _fileActionsFactory.GetActions(fileEntry),
                FileEntryType.Directory => _directoryActionsFactory.GetActions(fileEntry),
                _ => Enumerable.Empty<IFileEntryAction>()
            };
        }
    }
}