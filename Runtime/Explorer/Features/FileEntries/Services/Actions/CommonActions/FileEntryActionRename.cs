using System.Threading;
using System.Threading.Tasks;
using PhlegmaticOne.FileExplorer.Features.Actions.ViewModels;
using PhlegmaticOne.FileExplorer.Features.FileEntries.ViewModels;
using PhlegmaticOne.FileExplorer.Popups.Rename;
using PhlegmaticOne.FileExplorer.Services.Cancellation;

namespace PhlegmaticOne.FileExplorer.Features.FileEntries.Services.Actions
{
    internal sealed class FileEntryActionRename : FileEntryAction
    {
        private readonly IFileRenamePopupProvider _renamePopupProvider;

        public FileEntryActionRename(
            FileEntryViewModel fileEntry, 
            ActionsViewModel actionsViewModel,
            IExplorerCancellationProvider cancellationProvider,
            IFileEntryActionExecuteHandler executeHandler,
            IFileRenamePopupProvider renamePopupProvider) : 
            base(fileEntry, actionsViewModel, cancellationProvider, executeHandler)
        {
            _renamePopupProvider = renamePopupProvider;
        }

        public override string Description => "Rename";

        public override ActionColor Color => ActionColor.Auto;
        
        protected override async Task ExecuteAction(FileEntryViewModel fileEntry, CancellationToken token)
        {
            var renameData = await _renamePopupProvider.GetRenameData(fileEntry);

            if (renameData.WillRename)
            {
                fileEntry.Rename(renameData.NewName);
            }
        }
    }
}