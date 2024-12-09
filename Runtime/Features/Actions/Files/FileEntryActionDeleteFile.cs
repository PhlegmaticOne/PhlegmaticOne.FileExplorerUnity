using System.Threading.Tasks;
using PhlegmaticOne.FileExplorer.Core.Actions.ViewModels;

namespace PhlegmaticOne.FileExplorer.Features.Actions.Files
{
    internal sealed class FileEntryActionDeleteFile : FileEntryAction
    {
        public FileEntryActionDeleteFile(FileEntryActionsViewModel actionsViewModel) : base(actionsViewModel)
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