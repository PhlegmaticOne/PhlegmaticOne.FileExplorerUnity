using System.Threading;
using System.Threading.Tasks;
using UnityEngine;

namespace PhlegmaticOne.FileExplorer.Features.ExplorerIcons.Services
{
    internal interface IExplorerIconsProvider
    {
        bool IsPreviewImagesInsteadOfIcons { get; }
        Task<Sprite> GetIconAsync(string fileExtension, CancellationToken cancellationToken);
    }
}