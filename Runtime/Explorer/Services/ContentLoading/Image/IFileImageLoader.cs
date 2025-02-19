using System.Threading;
using System.Threading.Tasks;
using PhlegmaticOne.FileExplorer.Features.FileEntries.Entities;
using UnityEngine;

namespace PhlegmaticOne.FileExplorer.Services.ContentLoading
{
    internal interface IFileImageLoader
    {
        Task<FileContent<Sprite>> GetImage(FileEntryViewModel file, CancellationToken token);
    }
}