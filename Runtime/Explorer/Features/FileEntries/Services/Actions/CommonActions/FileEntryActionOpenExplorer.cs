#if UNITY_EDITOR
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using PhlegmaticOne.FileExplorer.Features.Actions.ViewModels;
using PhlegmaticOne.FileExplorer.Features.FileEntries.Services.Actions;
using PhlegmaticOne.FileExplorer.Features.FileEntries.Services.Actions.Handlers;
using PhlegmaticOne.FileExplorer.Services.Cancellation;
#if UNITY_EDITOR_OSX
using UnityEditor;
#endif

namespace PhlegmaticOne.FileExplorer.Features.FileEntries.ViewModels.Common.Actions
{
    internal sealed class FileEntryActionOpenExplorer : FileEntryAction
    {
        public FileEntryActionOpenExplorer(
            FileEntryViewModel fileEntry, 
            ActionsViewModel actionsViewModel,
            IExplorerCancellationProvider cancellationProvider,
            IFileEntryActionExecuteHandler executeHandler) : 
            base(fileEntry, actionsViewModel, cancellationProvider, executeHandler) { }

        public override string Description => "Open in OS";
        
        public override ActionColor Color => ActionColor.Auto;
        
        protected override Task ExecuteAction(FileEntryViewModel fileEntry, CancellationToken token)
        {
            var path = fileEntry.Path.Replace("/", "\\");
#if UNITY_EDITOR_WIN
            Process.Start("explorer.exe", "/select," + path);
#elif UNITY_EDITOR_OSX
            EditorUtility.RevealInFinder(path);
#endif
            return Task.CompletedTask;
        }
    }
}
#endif