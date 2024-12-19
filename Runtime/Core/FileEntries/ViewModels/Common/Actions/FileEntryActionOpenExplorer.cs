#if UNITY_EDITOR
using System.Diagnostics;
using System.Threading.Tasks;
using PhlegmaticOne.FileExplorer.Core.Actions.ViewModels;
using PhlegmaticOne.FileExplorer.Features.Actions;
#if UNITY_EDITOR_OSX
using UnityEditor;
#endif

namespace PhlegmaticOne.FileExplorer.Core.FileEntries.ViewModels.Common
{
    internal sealed class FileEntryActionOpenExplorer : FileEntryAction
    {
        public FileEntryActionOpenExplorer(FileEntryActionsViewModel actionsViewModel) : base(actionsViewModel)
        {
        }

        public override string Description => "Open in OS";
        
        public override FileEntryActionColor Color => FileEntryActionColor.Auto;
        
        protected override Task<bool> ExecuteAction()
        {
            var path = FileEntry.Path.Replace("/", "\\");
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