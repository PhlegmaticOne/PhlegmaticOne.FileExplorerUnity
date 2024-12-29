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
                ? Application.persistentDataPath.ToForwardSlash()
                : config.StartupLocation.ToForwardSlash();
        }

        public string RootPath { get; }
    }
}