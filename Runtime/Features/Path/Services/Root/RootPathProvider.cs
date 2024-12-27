using PhlegmaticOne.FileExplorer.Configuration;
using PhlegmaticOne.FileExplorer.Infrastructure.Extensions;
using UnityEngine;

namespace PhlegmaticOne.FileExplorer.Features.Path.Services.Root
{
    internal sealed class RootPathProvider : IRootPathProvider
    {
        public RootPathProvider(ExplorerConfig config)
        {
            RootPath = string.IsNullOrEmpty(config.StartupLocation)
                ? Application.persistentDataPath.PathSlash()
                : config.StartupLocation.PathSlash();
        }

        public string RootPath { get; }
    }
}