using System.Threading;
using System.Threading.Tasks;
using PhlegmaticOne.FileExplorer.Features.Actions.ViewModels;
using PhlegmaticOne.FileExplorer.Features.FileEntries.Services.Operations;
using PhlegmaticOne.FileExplorer.Features.FileEntries.ViewModels;
using PhlegmaticOne.FileExplorer.Features.Searching.ViewModels;
using PhlegmaticOne.FileExplorer.Features.Selection.ViewModels;
using PhlegmaticOne.FileExplorer.Features.Tab.ViewModels;
using PhlegmaticOne.FileExplorer.Services.Cancellation;

namespace PhlegmaticOne.FileExplorer.Features.FileEntries.Services.Actions
{
    internal sealed class FileEntryActionDelete : FileEntryAction
    {
        private readonly TabViewModel _tabViewModel;
        private readonly SelectionViewModel _selectionViewModel;
        private readonly SearchViewModel _searchViewModel;
        private readonly IFileOperations _fileOperations;

        public FileEntryActionDelete(
            FileEntryViewModel fileEntry, 
            ActionsViewModel actionsViewModel,
            IExplorerCancellationProvider cancellationProvider,
            IFileEntryActionExecuteHandler executeHandler,
            TabViewModel tabViewModel,
            SelectionViewModel selectionViewModel,
            SearchViewModel searchViewModel) : base(fileEntry, actionsViewModel, cancellationProvider, executeHandler)
        {
            _tabViewModel = tabViewModel;
            _selectionViewModel = selectionViewModel;
            _searchViewModel = searchViewModel;
        }

        public override string Description => "Delete";
        
        public override ActionColor Color => ActionColor.WithTextColor(UnityEngine.Color.red);
        
        protected override Task ExecuteAction(FileEntryViewModel fileEntry, CancellationToken token)
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