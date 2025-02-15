using System.Threading;
using System.Threading.Tasks;
using PhlegmaticOne.FileExplorer.Features.FileEntries.Entities;
using UnityEngine;

namespace PhlegmaticOne.FileExplorer.Popups.FileView
{
    internal interface IFileViewAudioProvider
    {
        Task ViewAudioFile(FileEntryViewModel file, AudioType audioType, CancellationToken token);
    }
}