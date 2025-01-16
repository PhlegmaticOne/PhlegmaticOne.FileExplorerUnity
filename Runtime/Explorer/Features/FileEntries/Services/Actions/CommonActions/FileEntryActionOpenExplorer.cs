#if UNITY_EDITOR
using System.Diagnostics;
using System.Threading.Tasks;
using PhlegmaticOne.FileExplorer.Features.Actions.ViewModels;
using PhlegmaticOne.FileExplorer.Features.FileEntries.Services.Actions;
using PhlegmaticOne.FileExplorer.Features.FileEntries.Services.Actions.Handlers;
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
            IFileEntryActionExecuteHandler executeHandler) : 
            base(fileEntry, actionsViewModel, executeHandler) { }

        public override string Description => "Open in OS";
        
        public override ActionColor Color => ActionColor.Auto;
        
        protected override Task<bool> ExecuteAction(FileEntryViewModel fileEntry)
        {
            var path = fileEntry.Path.Replace("/", "\\");
#if UNITY_EDITOR_WIN
            Process.Start("explorer.exe", "/select," + path);
#elif UNITY_EDITOR_OSX
            EditorUtility.RevealInFinder(path);
#endif
            return Task.FromResult(true);
        }
    }
}
#endif