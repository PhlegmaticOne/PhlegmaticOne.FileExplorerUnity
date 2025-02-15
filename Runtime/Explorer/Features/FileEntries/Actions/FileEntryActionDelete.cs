using System.Threading;
using System.Threading.Tasks;
using PhlegmaticOne.FileExplorer.Features.FileEntries.Core.Actions;
using PhlegmaticOne.FileExplorer.Features.FileEntries.Entities;
using PhlegmaticOne.FileExplorer.Features.Searching.Entities;
using PhlegmaticOne.FileExplorer.Features.Selection.Entities;
using PhlegmaticOne.FileExplorer.Features.Tab.Entities;

namespace PhlegmaticOne.FileExplorer.Features.FileEntries.Actions
{
    internal sealed class FileEntryActionDelete : IFileEntryAction
    {
        private readonly TabViewModel _tabViewModel;
        private readonly SelectionViewModel _selectionViewModel;
        private readonly SearchViewModel _searchViewModel;

        public FileEntryActionDelete(
            TabViewModel tabViewModel,
            SelectionViewModel selectionViewModel,
            SearchViewModel searchViewModel)
        {
            _tabViewModel = tabViewModel;
            _selectionViewModel = selectionViewModel;
            _searchViewModel = searchViewModel;
        }

        public Task Execute(FileEntryViewModel fileEntry, CancellationToken token)
        {
            fileEntry.Delete();
            _tabViewModel.Remove(fileEntry);

            if (fileEntry.IsSelected)
            {
                _selectionViewModel.UpdateSelection(fileEntry);
            }
            
            _searchViewModel.Research();
            return Task.CompletedTask;
        }
    }
}