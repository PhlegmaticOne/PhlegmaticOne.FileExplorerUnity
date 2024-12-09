using System.Threading.Tasks;
using PhlegmaticOne.FileExplorer.Core.Actions.ViewModels;

namespace PhlegmaticOne.FileExplorer.Features.Actions.Files
{
    internal sealed class FileEntryActionRenameFile : FileEntryAction
    {
        public FileEntryActionRenameFile(FileEntryActionsViewModel actionsViewModel) : base(actionsViewModel)
        {
        }

        public override string Description => "Rename";

        public override FileEntryActionColor Color => FileEntryActionColor.Empty;

        protected override Task<bool> ExecuteAction()
        {
            return Task.FromResult(true);
        }
    }
}