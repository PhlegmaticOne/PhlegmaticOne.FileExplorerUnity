using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using PhlegmaticOne.FileExplorer.Configuration;
using PhlegmaticOne.FileExplorer.Infrastructure.Extensions;
using PhlegmaticOne.FileExplorer.Services.Internet;
using UnityEngine;
using TaskExtensions = PhlegmaticOne.FileExplorer.Infrastructure.Extensions.TaskExtensions;

namespace PhlegmaticOne.FileExplorer.Features.FileEntries.Services.Icons
{
    internal sealed class ExplorerIconsLoader : IExplorerIconsLoader
    {
        private const string ContentDirectory = "Explorer";
        private const string Extension = ".png";

        private readonly IWebFileLoader _webFileLoader;
        private readonly IInternetProvider _internetProvider;
        private readonly string _contentPath;
        
        public ExplorerIconsLoader(IWebFileLoader webFileLoader, IInternetProvider internetProvider)
        {
            _webFileLoader = webFileLoader;
            _internetProvider = internetProvider;
            _contentPath = System.IO.Path.Combine(Application.persistentDataPath, ContentDirectory);
            EnsureDirectoryCreated(_contentPath);
        }

        public async Task<Sprite> LoadIconAsync(
            string extension, ExplorerIconsConfig config, CancellationToken cancellationToken)
        {
            if (config.IconsLoadType == ExplorerIconsLoadType.UseInBuildIconsAlways)
            {
                return await LoadIconFromResources(extension, config, cancellationToken);
            }
            
            var fileName = extension + Extension;
            var filePath = System.IO.Path.Combine(_contentPath, fileName);
            var spriteFromLocalFile = await LoadIconFromLocalFile(filePath, cancellationToken);

            if (spriteFromLocalFile != null)
            {
                return spriteFromLocalFile;
            }
            
            if (_internetProvider.IsAvailable)
            {
                return await LoadIconFromWeb(
                    extension, fileName, filePath, config, cancellationToken);
            }

            return await LoadIconFromResources(extension, config, cancellationToken);
        }

        private static async Task<Sprite> LoadIconFromLocalFile(
            string filePath, CancellationToken cancellationToken)
        {
            if (File.Exists(filePath))
            {
                var bytesFromFile = await File.ReadAllBytesAsync(filePath, cancellationToken);
                return bytesFromFile.CreateSpriteFromBytes();
            }

            return null;
        }

        private async Task<Sprite> LoadIconFromWeb(
            string extension, string fileName, string filePath, 
            ExplorerIconsConfig config, CancellationToken cancellationToken)
        {
            var iconUrl = new Uri(new Uri(config.IconsWebDirectoryUrl), fileName);
            
            var iconLoadResult = await _webFileLoader
                .LoadAsync(iconUrl.AbsoluteUri, config.WebLoadTimeout, cancellationToken);

            if (!iconLoadResult.HasError())
            {
                await File.WriteAllBytesAsync(filePath, iconLoadResult.Value, cancellationToken);
                return iconLoadResult.Value.CreateSpriteFromBytes();
            }

            return await LoadIconFromResources(extension, config, cancellationToken);
        }

        private static Task<Sprite> LoadIconFromResources(
            string extension, ExplorerIconsConfig config, CancellationToken cancellationToken)
        {
            var path = extension switch
            {
                "directory" => config.InBuildData.DirectoryIconPath,
                _ => config.InBuildData.FileIconPath
            };

            return TaskExtensions.LoadFromResourcesAsync<Sprite>(path, cancellationToken);
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