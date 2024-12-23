using System.Threading.Tasks;
using PhlegmaticOne.FileExplorer.Features.Actions.ViewModels;
using PhlegmaticOne.FileExplorer.Features.FileEntries.Services.Actions;
using PhlegmaticOne.FileExplorer.Features.FileEntries.Services.Actions.Handlers;
using PhlegmaticOne.FileExplorer.Features.FileEntries.Services.Operations;
using PhlegmaticOne.FileExplorer.Features.Searching.ViewModels;
using PhlegmaticOne.FileExplorer.Features.Selection.ViewModels;
using PhlegmaticOne.FileExplorer.Features.Tab.ViewModels;

namespace PhlegmaticOne.FileExplorer.Features.FileEntries.ViewModels.Common.Actions
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
            IFileEntryActionStartHandler actionStartHandler,
            IFileEntryActionErrorHandler actionErrorHandler,
            TabViewModel tabViewModel,
            SelectionViewModel selectionViewModel,
            SearchViewModel searchViewModel) : base(fileEntry, actionsViewModel, actionStartHandler, actionErrorHandler)
        {
            _tabViewModel = tabViewModel;
            _selectionViewModel = selectionViewModel;
            _searchViewModel = searchViewModel;
        }

        public override string Description => "Delete";
        
        public override ActionColor Color => 
            ActionColor.WithTextColor(UnityEngine.Color.red);
        
        protected override Task<bool> ExecuteAction(FileEntryViewModel fileEntry)
        {
            fileEntry.Delete();
            _tabViewModel.Remove(fileEntry);
            _selectionViewModel.UpdateSelection(fileEntry);
            _searchViewModel.Research();
            return Task.FromResult(true);
        }
    }
}