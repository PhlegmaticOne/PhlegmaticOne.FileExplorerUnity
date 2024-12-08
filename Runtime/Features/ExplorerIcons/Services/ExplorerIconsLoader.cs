using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using PhlegmaticOne.FileExplorer.Configuration;
using PhlegmaticOne.FileExplorer.Features.ExplorerIcons.WebLoading;
using PhlegmaticOne.FileExplorer.Infrastructure.Extensions;
using UnityEngine;

namespace PhlegmaticOne.FileExplorer.Features.ExplorerIcons.Services
{
    internal sealed class ExplorerIconsLoader : IExplorerIconsLoader
    {
        private const string ContentDirectory = "Explorer";
        private const string Extension = ".png";

        private readonly IWebFileLoader _webFileLoader;
        private readonly string _contentPath;
        
        public ExplorerIconsLoader(IWebFileLoader webFileLoader)
        {
            _webFileLoader = webFileLoader;
            _contentPath = Path.Combine(Application.persistentDataPath, ContentDirectory);
            EnsureDirectoryCreated(_contentPath);
        }

        public async Task<Sprite> LoadIconAsync(string fileExtension, ExplorerIconsConfig config, CancellationToken cancellationToken)
        {
            var fileName = fileExtension + Extension;
            var iconUrl = new Uri(new Uri(config.IconsWebDirectoryUrl), fileName);
            var filePath = Path.Combine(_contentPath, fileName);

            if (File.Exists(filePath))
            {
                var bytesFromFile = await File.ReadAllBytesAsync(filePath, cancellationToken);
                return bytesFromFile.CreateSpriteFromBytes();
            }

            var iconLoadResult = await _webFileLoader.LoadAsync(iconUrl.AbsoluteUri, cancellationToken);

            if (!iconLoadResult.HasError())
            {
                await File.WriteAllBytesAsync(filePath, iconLoadResult.Value, cancellationToken);
                return iconLoadResult.Value.CreateSpriteFromBytes();
            }

            return null;
        }

        private static void EnsureDirectoryCreated(string path)
        {
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
        }
    }
}