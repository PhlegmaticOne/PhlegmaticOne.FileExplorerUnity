using System.Threading;
using System.Threading.Tasks;
using PhlegmaticOne.FileExplorer.Features.FileEntries.ViewModels;
using UnityEngine;

namespace PhlegmaticOne.FileExplorer.Popups.FileView
{
    internal interface IFileAudioLoader
    {
        Task<FileViewContent<AudioClip>> LoadClip(
            FileEntryViewModel file, AudioType audioType, CancellationToken cancellationToken);
    }
}