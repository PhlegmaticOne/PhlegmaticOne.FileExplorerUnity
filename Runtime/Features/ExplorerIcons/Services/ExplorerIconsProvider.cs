using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using PhlegmaticOne.FileExplorer.Configuration;
using PhlegmaticOne.FileExplorer.Infrastructure.Extensions;
using UnityEngine;

namespace PhlegmaticOne.FileExplorer.Features.ExplorerIcons.Services
{
    internal sealed class ExplorerIconsProvider : IExplorerIconsProvider
    {
        private const string NoneExtension = "none";
        
        private readonly IExplorerIconsLoader _iconsLoader;
        private readonly FileExplorerConfig _config;
        private readonly Dictionary<string, Sprite> _explorerIcons;

        public ExplorerIconsProvider(IExplorerIconsLoader iconsLoader, FileExplorerConfig config)
        {
            _iconsLoader = iconsLoader;
            _config = config;
            _explorerIcons = new Dictionary<string, Sprite>();
        }

        public bool IsPreviewImagesInsteadOfIcons => _config.IconsConfig.IsPreviewImagesInsteadOfIcons;

        public async Task<Sprite> GetIconAsync(string fileExtension, CancellationToken cancellationToken)
        {
            var extension = string.IsNullOrEmpty(fileExtension) ? NoneExtension : fileExtension;
            var fileIcon = await LoadIcon(extension, cancellationToken);
            return fileIcon == null ? await LoadIcon(NoneExtension, cancellationToken) : fileIcon;
        }

        public void Dispose()
        {
            foreach (var explorerIcon in _explorerIcons)
            {
                explorerIcon.Value.Dispose();
            }
            
            _explorerIcons.Clear();
        }

        private async Task<Sprite> LoadIcon(string fileExtension, CancellationToken cancellationToken)
        {
            if (_explorerIcons.TryGetValue(fileExtension, out var fileIcon))
            {
                return fileIcon;
            }
            
            fileIcon = await _iconsLoader.LoadIconAsync(fileExtension, _config.IconsConfig, cancellationToken);
            _explorerIcons.TryAdd(fileExtension, fileIcon);
            return fileIcon;
        }
    }
}