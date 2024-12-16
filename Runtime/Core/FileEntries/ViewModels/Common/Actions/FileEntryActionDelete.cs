using System.Threading.Tasks;
using PhlegmaticOne.FileExplorer.Core.Actions.ViewModels;
using PhlegmaticOne.FileExplorer.Core.Tab.ViewModels;
using PhlegmaticOne.FileExplorer.Features.Actions;
using PhlegmaticOne.FileExplorer.Features.FileOperations;

namespace PhlegmaticOne.FileExplorer.Core.FileEntries.ViewModels.Common
{
    internal sealed class FileEntryActionDelete : FileEntryAction
    {
        private readonly TabViewModel _tabViewModel;
        private readonly IFileOperations _fileOperations;

        public FileEntryActionDelete(
            TabViewModel tabViewModel,
            FileEntryActionsViewModel actionsViewModel) : base(actionsViewModel)
        {
            _tabViewModel = tabViewModel;
        }

        public override string Description => "Delete";
        
        public override FileEntryActionColor Color => 
            FileEntryActionColor.WithTextColor(UnityEngine.Color.red);
        
        protected override Task<bool> ExecuteAction()
        {
            FileEntry.Delete();
            _tabViewModel.Remove(FileEntry);
            return Task.FromResult(true);
        }
    }
}