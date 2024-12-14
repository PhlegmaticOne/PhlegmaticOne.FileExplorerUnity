using System.Threading.Tasks;
using PhlegmaticOne.FileExplorer.Core.Actions.ViewModels;
using PhlegmaticOne.FileExplorer.Core.Tab.ViewModels;
using PhlegmaticOne.FileExplorer.Features.Actions;
using PhlegmaticOne.FileExplorer.Features.FileOperations;

namespace PhlegmaticOne.FileExplorer.Core.FileEntries.ViewModels.Common
{
    internal sealed class FileEntryActionDelete : FileEntryAction
    {
        private readonly FileEntryViewModel _viewModel;
        private readonly TabViewModel _tabViewModel;
        private readonly IFileOperations _fileOperations;

        public FileEntryActionDelete(
            FileEntryViewModel viewModel,
            TabViewModel tabViewModel,
            FileEntryActionsViewModel actionsViewModel) : base(actionsViewModel)
        {
            _viewModel = viewModel;
            _tabViewModel = tabViewModel;
        }

        public override string Description => "Delete";
        
        public override FileEntryActionColor Color => 
            FileEntryActionColor.WithTextColor(UnityEngine.Color.red);
        
        protected override Task<bool> ExecuteAction()
        {
            _viewModel.Delete();
            _tabViewModel.Remove(_viewModel);
            return Task.FromResult(true);
        }
    }
}