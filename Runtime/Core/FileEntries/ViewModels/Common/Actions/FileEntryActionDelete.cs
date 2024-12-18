using System.Threading.Tasks;
using PhlegmaticOne.FileExplorer.Core.Actions.ViewModels;
using PhlegmaticOne.FileExplorer.Core.Searching.ViewModels;
using PhlegmaticOne.FileExplorer.Core.Selection.ViewModels;
using PhlegmaticOne.FileExplorer.Core.Tab.ViewModels;
using PhlegmaticOne.FileExplorer.Features.Actions;
using PhlegmaticOne.FileExplorer.Features.FileOperations;

namespace PhlegmaticOne.FileExplorer.Core.FileEntries.ViewModels.Common
{
    internal sealed class FileEntryActionDelete : FileEntryAction
    {
        private readonly TabViewModel _tabViewModel;
        private readonly SelectionViewModel _selectionViewModel;
        private readonly SearchViewModel _searchViewModel;
        private readonly IFileOperations _fileOperations;

        public FileEntryActionDelete(
            TabViewModel tabViewModel,
            FileEntryActionsViewModel actionsViewModel,
            SelectionViewModel selectionViewModel,
            SearchViewModel searchViewModel) : base(actionsViewModel)
        {
            _tabViewModel = tabViewModel;
            _selectionViewModel = selectionViewModel;
            _searchViewModel = searchViewModel;
        }

        public override string Description => "Delete";
        
        public override FileEntryActionColor Color => 
            FileEntryActionColor.WithTextColor(UnityEngine.Color.red);
        
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