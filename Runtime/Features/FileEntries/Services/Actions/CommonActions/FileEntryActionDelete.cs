using System.Threading.Tasks;
using PhlegmaticOne.FileExplorer.Features.Actions.Base;
using PhlegmaticOne.FileExplorer.Features.Actions.ViewModels;
using PhlegmaticOne.FileExplorer.Features.FileEntries.Services.Actions;
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
            TabViewModel tabViewModel,
            ActionsViewModel actionsViewModel,
            SelectionViewModel selectionViewModel,
            SearchViewModel searchViewModel) : base(actionsViewModel)
        {
            _tabViewModel = tabViewModel;
            _selectionViewModel = selectionViewModel;
            _searchViewModel = searchViewModel;
        }

        public override string Description => "Delete";
        
        public override ExplorerActionColor Color => 
            ExplorerActionColor.WithTextColor(UnityEngine.Color.red);
        
        protected override Task<bool> ExecuteAction()
        {
            FileEntry.Delete();
            _tabViewModel.Remove(FileEntry);
            _selectionViewModel.UpdateSelection(FileEntry);
            _searchViewModel.Research();
            return Task.FromResult(true);
        }
    }
}