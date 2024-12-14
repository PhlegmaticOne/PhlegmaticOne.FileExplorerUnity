using System.IO;
using System.Threading.Tasks;
using PhlegmaticOne.FileExplorer.Core.Actions.ViewModels;
using PhlegmaticOne.FileExplorer.Core.FileEntries.ViewModels;
using PhlegmaticOne.FileExplorer.Core.Tab.ViewModels;

namespace PhlegmaticOne.FileExplorer.Features.Actions.Files
{
    internal sealed class FileEntryActionDeleteFile : FileEntryAction
    {
        private readonly FileEntryViewModel _fileEntryViewModel;
        private readonly TabViewModel _tabViewModel;

        public FileEntryActionDeleteFile(
            FileEntryViewModel fileEntryViewModel,
            TabViewModel tabViewModel,
            FileEntryActionsViewModel actionsViewModel) : base(actionsViewModel)
        {
            _fileEntryViewModel = fileEntryViewModel;
            _tabViewModel = tabViewModel;
        }

        public override string Description => "Delete";
        public override FileEntryActionColor Color => FileEntryActionColor.WithTextColor(UnityEngine.Color.red);
        protected override Task<bool> ExecuteAction()
        {
            File.Delete(_fileEntryViewModel.Path);
            _tabViewModel.Remove(_fileEntryViewModel);
            return Task.FromResult(true);
        }
    }
}