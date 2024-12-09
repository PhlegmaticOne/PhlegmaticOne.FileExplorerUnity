using System.Collections.Generic;
using PhlegmaticOne.FileExplorer.Core.Actions.ViewModels;
using PhlegmaticOne.FileExplorer.Core.FileEntries.ViewModels;

namespace PhlegmaticOne.FileExplorer.Features.Actions.Files
{
    internal sealed class FileEntryActionsFactoryFile : FileEntryActionsFactory<FileViewModel>
    {
        private readonly FileEntryActionsViewModel _actionsViewModel;

        public FileEntryActionsFactoryFile(FileEntryActionsViewModel actionsViewModel)
        {
            _actionsViewModel = actionsViewModel;
        }
        
        protected override IEnumerable<IFileEntryAction> GetActions(FileViewModel fileEntry)
        {
            yield return new FileEntryActionRenameFile(_actionsViewModel);
            yield return new FileEntryActionFileProperties(_actionsViewModel);
            yield return new FileEntryActionDeleteFile(_actionsViewModel);
        }
    }
}