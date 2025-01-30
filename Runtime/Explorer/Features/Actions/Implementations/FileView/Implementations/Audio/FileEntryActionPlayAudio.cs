using System.Threading;
using System.Threading.Tasks;
using PhlegmaticOne.FileExplorer.Features.Actions.ViewModels;
using PhlegmaticOne.FileExplorer.Features.FileEntries.Services.Actions;
using PhlegmaticOne.FileExplorer.Features.FileEntries.Services.Actions.Handlers;
using PhlegmaticOne.FileExplorer.Features.FileEntries.ViewModels;
using PhlegmaticOne.FileExplorer.Services.Cancellation;
using UnityEngine;

namespace PhlegmaticOne.FileExplorer.Features.Actions.Implementations.FileView.Implementations
{
    internal sealed class FileEntryActionPlayAudio : FileEntryAction
    {
        private readonly IFileViewAudioProvider _viewAudioProvider;

        public FileEntryActionPlayAudio(
            IFileViewAudioProvider viewAudioProvider,
            FileEntryViewModel fileEntry, 
            ActionsViewModel actionsViewModel, 
            IExplorerCancellationProvider cancellationProvider, 
            IFileEntryActionExecuteHandler executeHandler) : 
            base(fileEntry, actionsViewModel, cancellationProvider, executeHandler)
        {
            _viewAudioProvider = viewAudioProvider;
        }

        public override string Description => "Play audio";
        public override ActionColor Color => ActionColor.WithTextColor(UnityEngine.Color.yellow);
        
        protected override Task ExecuteAction(FileEntryViewModel fileEntry, CancellationToken token)
        {
            return _viewAudioProvider.ViewAudioAsync(fileEntry, AudioType.WAV, token);
        }
    }
}