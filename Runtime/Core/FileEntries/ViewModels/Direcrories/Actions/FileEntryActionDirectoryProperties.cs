using System.Threading.Tasks;
using PhlegmaticOne.FileExplorer.Core.Actions.ViewModels;
using PhlegmaticOne.FileExplorer.Features.Actions;

namespace PhlegmaticOne.FileExplorer.Core.FileEntries.ViewModels.Directories
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