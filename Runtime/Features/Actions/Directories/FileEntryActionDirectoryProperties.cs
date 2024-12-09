using System.Threading.Tasks;
using PhlegmaticOne.FileExplorer.Core.Actions.ViewModels;

namespace PhlegmaticOne.FileExplorer.Features.Actions.Directories
{
    internal sealed class FileEntryActionDirectoryProperties : FileEntryAction
    {
        public FileEntryActionDirectoryProperties(FileEntryActionsViewModel actionsViewModel) : base(actionsViewModel)
        {
        }

        public override string Description => "Properties";
        public override FileEntryActionColor Color => FileEntryActionColor.Empty;
        protected override Task<bool> ExecuteAction()
        {
            return Task.FromResult(true);
        }
    }
}