using PhlegmaticOne.FileExplorer.Configuration;
using PhlegmaticOne.FileExplorer.Infrastructure.Extensions;
using UnityEngine;

namespace PhlegmaticOne.FileExplorer.Features.Path.Services.Root
{
    internal sealed class RootPathProvider : IRootPathProvider
    {
        public RootPathProvider(ExplorerConfig config)
        {
            RootPath = BuildRootPath(config);
        }

        public string RootPath { get; }

        private static string BuildRootPath(ExplorerConfig config)
        {
#if UNITY_EDITOR
            return string.IsNullOrEmpty(config.StartupLocation)
                ? Application.persistentDataPath.ToForwardSlash()
                : config.StartupLocation.ToForwardSlash();
#else
            return string.IsNullOrEmpty(config.StartupLocation)
                ? Application.persistentDataPath.ToForwardSlash()
                : System.IO.Path.Combine(Application.persistentDataPath, config.StartupLocation).ToForwardSlash();
#endif
        }
    }
}