using System.Collections.Generic;
using PhlegmaticOne.FileExplorer.Core.Actions.ViewModels;
using PhlegmaticOne.FileExplorer.Core.FileEntries.ViewModels;
using PhlegmaticOne.FileExplorer.Core.Tab.ViewModels;

namespace PhlegmaticOne.FileExplorer.Features.Actions.Files
{
    internal sealed class FileEntryActionsFactoryFile : FileEntryActionsFactory<FileViewModel>
    {
        private readonly FileEntryActionsViewModel _actionsViewModel;
        private readonly TabViewModel _tabViewModel;

        public FileEntryActionsFactoryFile(
            FileEntryActionsViewModel actionsViewModel,
            TabViewModel tabViewModel)
        {
            _actionsViewModel = actionsViewModel;
            _tabViewModel = tabViewModel;
        }
        
        protected override IEnumerable<IFileEntryAction> GetActions(FileViewModel fileEntry)
        {
            yield return new FileEntryActionRenameFile(_actionsViewModel);
            yield return new FileEntryActionFileProperties(_actionsViewModel);
            yield return new FileEntryActionDeleteFile(fileEntry, _tabViewModel, _actionsViewModel);
        }
    }
}