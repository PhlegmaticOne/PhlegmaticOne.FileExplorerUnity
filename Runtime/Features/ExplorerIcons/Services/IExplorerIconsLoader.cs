using System.Threading.Tasks;
using PhlegmaticOne.FileExplorer.Configuration;
using UnityEngine;

namespace PhlegmaticOne.FileExplorer.Features.ExplorerIcons.Services
{
    internal interface IExplorerIconsLoader
    {
        Task<Sprite> LoadIconAsync(string fileExtension, ExplorerIconsConfig config);
    }
}