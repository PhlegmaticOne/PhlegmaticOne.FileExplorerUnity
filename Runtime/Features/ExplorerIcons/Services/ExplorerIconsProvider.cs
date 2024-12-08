using System.Collections.Generic;
using System.Threading.Tasks;
using PhlegmaticOne.FileExplorer.Configuration;
using UnityEngine;

namespace PhlegmaticOne.FileExplorer.Features.ExplorerIcons.Services
{
    internal sealed class ExplorerIconsProvider : IExplorerIconsProvider
    {
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

        public async Task<Sprite> GetIconAsync(string fileExtension)
        {
            if (_explorerIcons.TryGetValue(fileExtension, out var fileIcon))
            {
                return fileIcon;
            }

            fileIcon = await _iconsLoader.LoadIconAsync(fileExtension, _config.IconsConfig);
            _explorerIcons.TryAdd(fileExtension, fileIcon);
            return fileIcon;
        }
    }
}