#if UNITY_EDITOR
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using PhlegmaticOne.FileExplorer.Features.FileEntries.Actions.Core;
using PhlegmaticOne.FileExplorer.Features.FileEntries.Entities;
#if UNITY_EDITOR_OSX
using UnityEditor;
#endif

namespace PhlegmaticOne.FileExplorer.Features.FileEntries.Actions
{
    internal sealed class FileEntryActionOpenExplorer : IFileEntryAction
    {
        public Task Execute(FileEntryViewModel fileEntry, CancellationToken token)
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