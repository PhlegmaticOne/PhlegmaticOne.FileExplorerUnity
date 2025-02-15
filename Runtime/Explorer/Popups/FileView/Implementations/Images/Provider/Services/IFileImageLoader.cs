using System.Threading;
using System.Threading.Tasks;
using PhlegmaticOne.FileExplorer.Features.FileEntries.Entities;
using UnityEngine;

namespace PhlegmaticOne.FileExplorer.Popups.FileView
{
    internal interface IFileImageLoader
    {
        Task<FileViewContent<Sprite>> GetImage(FileEntryViewModel file, CancellationToken token);
    }
}