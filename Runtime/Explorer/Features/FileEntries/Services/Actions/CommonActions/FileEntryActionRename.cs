using System.Threading;
using System.Threading.Tasks;
using PhlegmaticOne.FileExplorer.Features.Actions.Implementations.Rename.Services;
using PhlegmaticOne.FileExplorer.Features.Actions.ViewModels;
using PhlegmaticOne.FileExplorer.Features.FileEntries.Services.Actions;
using PhlegmaticOne.FileExplorer.Features.FileEntries.Services.Actions.Handlers;
using PhlegmaticOne.FileExplorer.Services.Cancellation;

namespace PhlegmaticOne.FileExplorer.Features.FileEntries.ViewModels.Common.Actions
{
    internal sealed class FileEntryActionRename : FileEntryAction
    {
        private readonly IFileRenameDataProvider _renameDataProvider;

        public FileEntryActionRename(
            FileEntryViewModel fileEntry, 
            ActionsViewModel actionsViewModel,
            IExplorerCancellationProvider cancellationProvider,
            IFileEntryActionExecuteHandler executeHandler,
            IFileRenameDataProvider renameDataProvider) : 
            base(fileEntry, actionsViewModel, cancellationProvider, executeHandler)
        {
            _renameDataProvider = renameDataProvider;
        }

        public override string Description => "Rename";

        public override ActionColor Color => ActionColor.Auto;
        
        protected override async Task ExecuteAction(FileEntryViewModel fileEntry, CancellationToken token)
        {
            var renameData = await _renameDataProvider.GetRenameData(fileEntry);

            if (renameData.WillRename)
            {
                fileEntry.Rename(renameData.NewName);
            }
        }
    }
}