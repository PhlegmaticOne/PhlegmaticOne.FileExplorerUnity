using PhlegmaticOne.FileExplorer.Features.Actions.Base;
using PhlegmaticOne.FileExplorer.Features.Actions.ViewModels;
using PhlegmaticOne.FileExplorer.Features.FileEntries.ViewModels;

namespace PhlegmaticOne.FileExplorer.Features.FileEntries.Services.Actions
{
    internal abstract class FileEntryAction : ExplorerAction
    {
        protected FileEntryAction(ActionsViewModel actionsViewModel) : base(actionsViewModel) { }

        protected FileEntryViewModel FileEntry { get; private set; }
        
        public FileEntryAction WithFileEntry(FileEntryViewModel fileEntry)
        {
            FileEntry = fileEntry;
            return this;
        }
    }
}