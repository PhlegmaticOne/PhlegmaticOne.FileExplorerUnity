using System.Threading;
using System.Threading.Tasks;
using PhlegmaticOne.FileExplorer.Features.Actions.ViewModels;
using PhlegmaticOne.FileExplorer.Features.FileEntries.Services.Actions;
using PhlegmaticOne.FileExplorer.Popups.FileView;
using PhlegmaticOne.FileExplorer.Services.Cancellation;

namespace PhlegmaticOne.FileExplorer.Features.FileEntries.ViewModels.Files.Actions
{
    internal sealed class FileEntryActionShowText : FileEntryAction
    {
        private readonly IFileViewTextProvider _viewTextProvider;

        public FileEntryActionShowText(
            IFileViewTextProvider viewTextProvider,
            FileEntryViewModel fileEntry, 
            ActionsViewModel actionsViewModel, 
            IExplorerCancellationProvider cancellationProvider, 
            IFileEntryActionExecuteHandler executeHandler) : 
            base(fileEntry, actionsViewModel, cancellationProvider, executeHandler)
        {
            _viewTextProvider = viewTextProvider;
        }

        public override string Description => "View text";
        public override ActionColor Color => ActionColor.WithTextColor(UnityEngine.Color.yellow);
        protected override Task ExecuteAction(FileEntryViewModel fileEntry, CancellationToken token)
        {
            return _viewTextProvider.ViewTextAsync(fileEntry, token);
        }
    }
}