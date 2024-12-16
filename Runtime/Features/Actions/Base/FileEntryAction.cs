using System.Threading.Tasks;
using PhlegmaticOne.FileExplorer.Core.Actions.ViewModels;
using PhlegmaticOne.FileExplorer.Core.FileEntries.ViewModels;

namespace PhlegmaticOne.FileExplorer.Features.Actions
{
    internal abstract class FileEntryAction : IFileEntryAction
    {
        private readonly FileEntryActionsViewModel _actionsViewModel;

        protected FileEntryAction(FileEntryActionsViewModel actionsViewModel)
        {
            _actionsViewModel = actionsViewModel;
        }

        protected FileEntryViewModel FileEntry { get; private set; }
        
        public abstract string Description { get; }
        public abstract FileEntryActionColor Color { get; }

        public FileEntryAction WithFileEntry(FileEntryViewModel fileEntry)
        {
            FileEntry = fileEntry;
            return this;
        }
        
        public Task<bool> Execute()
        {
            _actionsViewModel.Deactivate();
            return ExecuteAction();
        }

        protected abstract Task<bool> ExecuteAction();
    }
}