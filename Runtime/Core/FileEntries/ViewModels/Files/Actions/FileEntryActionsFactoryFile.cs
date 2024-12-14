using System.Collections.Generic;
using PhlegmaticOne.FileExplorer.Core.Actions.ViewModels;
using PhlegmaticOne.FileExplorer.Core.FileEntries.ViewModels.Common;
using PhlegmaticOne.FileExplorer.Core.Tab.ViewModels;
using PhlegmaticOne.FileExplorer.Features.Actions;
using PhlegmaticOne.FileExplorer.Features.Actions.Rename;

namespace PhlegmaticOne.FileExplorer.Core.FileEntries.ViewModels.Files
{
    internal sealed class FileEntryActionsFactoryFile : FileEntryActionsFactory<FileViewModel>
    {
        private readonly FileEntryActionsViewModel _actionsViewModel;
        private readonly IFileEntryRenameDataProvider _renameDataProvider;
        private readonly TabViewModel _tabViewModel;

        public FileEntryActionsFactoryFile(
            FileEntryActionsViewModel actionsViewModel,
            IFileEntryRenameDataProvider renameDataProvider,
            TabViewModel tabViewModel)
        {
            _actionsViewModel = actionsViewModel;
            _renameDataProvider = renameDataProvider;
            _tabViewModel = tabViewModel;
        }
        
        protected override IEnumerable<IFileEntryAction> GetActions(FileViewModel fileEntry)
        {
            yield return new FileEntryActionRename(
                fileEntry, _renameDataProvider, _actionsViewModel);
            yield return new FileEntryActionFileProperties(_actionsViewModel);
            yield return new FileEntryActionDelete(
                fileEntry, _tabViewModel, _actionsViewModel);
        }
    }
}