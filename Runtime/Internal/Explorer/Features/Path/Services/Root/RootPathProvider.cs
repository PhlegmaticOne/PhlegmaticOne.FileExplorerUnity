using PhlegmaticOne.FileExplorer.Infrastructure.Extensions;
using UnityEngine;

namespace PhlegmaticOne.FileExplorer.Features.Path.Services.Root
{
    internal sealed class RootPathProvider : IRootPathProvider
    {
        public RootPathProvider(ExplorerShowConfiguration config)
        {
            RootPath = BuildRootPath(config);
        }

        public string RootPath { get; }

        private static string BuildRootPath(ExplorerShowConfiguration config)
        {
            return string.IsNullOrEmpty(config.StartupLocation)
                ? Application.persistentDataPath.ToForwardSlash()
                : config.StartupLocation.ToForwardSlash();
        }
    }
}