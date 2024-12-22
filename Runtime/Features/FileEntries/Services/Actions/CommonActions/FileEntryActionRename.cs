using System.Threading.Tasks;
using PhlegmaticOne.FileExplorer.Features.Actions.Base;
using PhlegmaticOne.FileExplorer.Features.Actions.Implementations.Rename.Services;
using PhlegmaticOne.FileExplorer.Features.Actions.ViewModels;
using PhlegmaticOne.FileExplorer.Features.FileEntries.Services.Actions;

namespace PhlegmaticOne.FileExplorer.Features.FileEntries.ViewModels.Common.Actions
{
    internal sealed class FileEntryActionRename : FileEntryAction
    {
        private readonly IFileRenameDataProvider _renameDataProvider;

        public FileEntryActionRename(
            IFileRenameDataProvider renameDataProvider,
            ActionsViewModel actionsViewModel) : base(actionsViewModel)
        {
            _renameDataProvider = renameDataProvider;
        }

        public override string Description => "Rename";

        public override ExplorerActionColor Color => ExplorerActionColor.Auto;

        protected override async Task<bool> ExecuteAction()
        {
            var renameData = await _renameDataProvider.GetRenameData(FileEntry);

            if (renameData.WillRename)
            {
                FileEntry.Rename(renameData.NewName);
            }

            return renameData.WillRename;
        }
    }
}