using System.Threading;
using System.Threading.Tasks;
using PhlegmaticOne.FileExplorer.Configuration;
using UnityEngine;

namespace PhlegmaticOne.FileExplorer.Features.FileEntries.Services.Icons.Services
{
    internal interface IExplorerIconsLoader
    {
        Task<Sprite> LoadIconAsync(string extension, ExplorerIconsConfig config, CancellationToken cancellationToken);
    }
}