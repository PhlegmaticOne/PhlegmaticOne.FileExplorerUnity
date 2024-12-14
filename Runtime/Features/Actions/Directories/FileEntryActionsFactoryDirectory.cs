using System.Collections.Generic;
using PhlegmaticOne.FileExplorer.Core.Actions.ViewModels;
using PhlegmaticOne.FileExplorer.Core.FileEntries.ViewModels;
using PhlegmaticOne.FileExplorer.Core.Tab.ViewModels;

namespace PhlegmaticOne.FileExplorer.Features.Actions.Directories
{
    internal sealed class FileEntryActionsFactoryDirectory : FileEntryActionsFactory<DirectoryViewModel>
    {
        private readonly FileEntryActionsViewModel _actionsViewModel;
        private readonly TabViewModel _tabViewModel;

        public FileEntryActionsFactoryDirectory(
            FileEntryActionsViewModel actionsViewModel,
            TabViewModel tabViewModel)
        {
            _actionsViewModel = actionsViewModel;
            _tabViewModel = tabViewModel;
        }
        
        protected override IEnumerable<IFileEntryAction> GetActions(DirectoryViewModel fileEntry)
        {
            yield return new FileEntryActionRenameDirectory(_actionsViewModel);
            yield return new FileEntryActionDirectoryProperties(_actionsViewModel);
            yield return new FileEntryActionDeleteDirectory(fileEntry, _actionsViewModel, _tabViewModel);
        }
    }
}