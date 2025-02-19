using System.Threading;
using System.Threading.Tasks;
using PhlegmaticOne.FileExplorer.Features.FileEntries.Entities;
using UnityEngine;

namespace PhlegmaticOne.FileExplorer.Services.ContentLoading
{
    internal interface IFileAudioLoader
    {
        Task<FileContent<AudioClip>> LoadClip(
            FileEntryViewModel file, AudioType audioType, CancellationToken cancellationToken);
    }
}