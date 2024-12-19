using PhlegmaticOne.FileExplorer.Core.Actions.ViewModels;
using PhlegmaticOne.FileExplorer.Core.FileEntries.ViewModels;

namespace PhlegmaticOne.FileExplorer.Features.Actions
{
    internal abstract class FileEntryAction : ExplorerAction
    {
        protected FileEntryAction(FileEntryActionsViewModel actionsViewModel) : base(actionsViewModel) { }

        protected FileEntryViewModel FileEntry { get; private set; }
        
        public FileEntryAction WithFileEntry(FileEntryViewModel fileEntry)
        {
            FileEntry = fileEntry;
            return this;
        }
    }
}