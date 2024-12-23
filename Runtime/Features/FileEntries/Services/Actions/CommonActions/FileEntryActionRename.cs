using System.Threading.Tasks;
using PhlegmaticOne.FileExplorer.Features.Actions.Implementations.Rename.Services;
using PhlegmaticOne.FileExplorer.Features.Actions.ViewModels;
using PhlegmaticOne.FileExplorer.Features.FileEntries.Services.Actions;
using PhlegmaticOne.FileExplorer.Features.FileEntries.Services.Actions.Handlers;

namespace PhlegmaticOne.FileExplorer.Features.FileEntries.ViewModels.Common.Actions
{
    internal sealed class FileEntryActionRename : FileEntryAction
    {
        private readonly IFileRenameDataProvider _renameDataProvider;

        public FileEntryActionRename(
            FileEntryViewModel fileEntry, 
            ActionsViewModel actionsViewModel,
            IFileEntryActionStartHandler actionStartHandler,
            IFileEntryActionErrorHandler actionErrorHandler,
            IFileRenameDataProvider renameDataProvider) : 
            base(fileEntry, actionsViewModel, actionStartHandler, actionErrorHandler)
        {
            _renameDataProvider = renameDataProvider;
        }

        public override string Description => "Rename";

        public override ActionColor Color => ActionColor.Auto;
        
        protected override async Task<bool> ExecuteAction(FileEntryViewModel fileEntry)
        {
            var renameData = await _renameDataProvider.GetRenameData(fileEntry);

            if (renameData.WillRename)
            {
                fileEntry.Rename(renameData.NewName);
            }

            return renameData.WillRename;
        }
    }
}