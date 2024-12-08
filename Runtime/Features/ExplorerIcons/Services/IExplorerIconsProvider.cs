using System;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;

namespace PhlegmaticOne.FileExplorer.Features.ExplorerIcons.Services
{
    internal interface IExplorerIconsProvider : IDisposable
    {
        bool IsPreviewImagesInsteadOfIcons { get; }
        Task<Sprite> GetIconAsync(string fileExtension, CancellationToken cancellationToken);
    }
}