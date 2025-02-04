using System.Threading;
using System.Threading.Tasks;
using PhlegmaticOne.FileExplorer.Features.FileEntries.ViewModels;
using UnityEngine;

namespace PhlegmaticOne.FileExplorer.Features.Actions.Implementations.FileView.Implementations
{
    internal interface IFileViewAudioProvider
    {
        Task ViewAudioFile(FileEntryViewModel file, AudioType audioType, CancellationToken token);
    }
}