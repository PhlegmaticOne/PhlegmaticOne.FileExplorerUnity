using System.Collections.Generic;
using PhlegmaticOne.FileExplorer.Core.Actions.ViewModels;
using PhlegmaticOne.FileExplorer.Core.FileEntries.ViewModels;

namespace PhlegmaticOne.FileExplorer.Features.Actions.Directories
{
    internal sealed class FileEntryActionsFactoryDirectory : FileEntryActionsFactory<DirectoryViewModel>
    {
        private readonly FileEntryActionsViewModel _actionsViewModel;

        public FileEntryActionsFactoryDirectory(FileEntryActionsViewModel actionsViewModel)
        {
            _actionsViewModel = actionsViewModel;
        }
        
        protected override IEnumerable<IFileEntryAction> GetActions(DirectoryViewModel fileEntry)
        {
            yield return new FileEntryActionRenameDirectory(_actionsViewModel);
            yield return new FileEntryActionDirectoryProperties(_actionsViewModel);
            yield return new FileEntryActionDeleteDirectory(_actionsViewModel);
        }
    }
}