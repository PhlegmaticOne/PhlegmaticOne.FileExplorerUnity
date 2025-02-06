using System.Threading;
using System.Threading.Tasks;
using PhlegmaticOne.FileExplorer.Features.Actions.ViewModels;
using PhlegmaticOne.FileExplorer.Features.FileEntries.Services.Actions;
using PhlegmaticOne.FileExplorer.Popups.FileView;
using PhlegmaticOne.FileExplorer.Services.Cancellation;

namespace PhlegmaticOne.FileExplorer.Features.FileEntries.ViewModels.Files.Actions
{
    internal sealed class FileEntryActionShowImage : FileEntryAction
    {
        private readonly IFileViewImageProvider _viewImageProvider;

        public FileEntryActionShowImage(
            IFileViewImageProvider viewImageProvider,
            FileEntryViewModel fileEntry, 
            ActionsViewModel actionsViewModel, 
            IExplorerCancellationProvider cancellationProvider, 
            IFileEntryActionExecuteHandler executeHandler) : 
            base(fileEntry, actionsViewModel, cancellationProvider, executeHandler)
        {
            _viewImageProvider = viewImageProvider;
        }

        public override string Description => "View image";
        public override ActionColor Color => ActionColor.WithTextColor(UnityEngine.Color.yellow);
        protected override Task ExecuteAction(FileEntryViewModel fileEntry, CancellationToken token)
        {
            return _viewImageProvider.ViewImageAsync(fileEntry, token);
        }
    }
}