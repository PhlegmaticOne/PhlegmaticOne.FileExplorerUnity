using System.Threading.Tasks;
using PhlegmaticOne.FileExplorer.Core.Actions.ViewModels;

namespace PhlegmaticOne.FileExplorer.Features.Actions.Directories
{
    internal sealed class FileEntryActionDeleteDirectory : FileEntryAction
    {
        public FileEntryActionDeleteDirectory(FileEntryActionsViewModel actionsViewModel) : base(actionsViewModel)
        {
        }

        public override string Description => "Delete";
        public override FileEntryActionColor Color => FileEntryActionColor.WithTextColor(UnityEngine.Color.red);
        protected override Task<bool> ExecuteAction()
        {
            return Task.FromResult(true);
        }
    }
}