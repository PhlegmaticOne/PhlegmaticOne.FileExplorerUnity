using System.IO;
using System.Threading.Tasks;
using PhlegmaticOne.FileExplorer.Core.Actions.ViewModels;
using PhlegmaticOne.FileExplorer.Core.FileEntries.ViewModels;
using PhlegmaticOne.FileExplorer.Core.Tab.ViewModels;

namespace PhlegmaticOne.FileExplorer.Features.Actions.Directories
{
    internal sealed class FileEntryActionDeleteDirectory : FileEntryAction
    {
        private readonly TabViewModel _tabViewModel;
        private readonly DirectoryViewModel _directoryViewModel;

        public FileEntryActionDeleteDirectory(
            DirectoryViewModel directoryViewModel,
            FileEntryActionsViewModel actionsViewModel,
            TabViewModel tabViewModel) : base(actionsViewModel)
        {
            _tabViewModel = tabViewModel;
            _directoryViewModel = directoryViewModel;
        }

        public override string Description => "Delete";
        public override FileEntryActionColor Color => FileEntryActionColor.WithTextColor(UnityEngine.Color.red);
        protected override Task<bool> ExecuteAction()
        {
            Directory.Delete(_directoryViewModel.Path, true);
            _tabViewModel.Remove(_directoryViewModel);
            return Task.FromResult(true);
        }
    }
}