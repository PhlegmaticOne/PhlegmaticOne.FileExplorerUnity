using System.IO;
using System.Threading.Tasks;
using PhlegmaticOne.FileExplorer.Core.FileEntries.ViewModels;
using PhlegmaticOne.FileExplorer.Features.ExplorerIcons.Services;
using PhlegmaticOne.FileExplorer.Infrastructure.Extensions;
using UnityEngine;

namespace PhlegmaticOne.FileExplorer.Features.ExplorerIcons
{
    internal sealed class ExplorerFileIcon
    {
        private readonly FileViewModel _viewModel;
        private readonly IExplorerIconsProvider _iconsProvider;

        private Sprite _fileIcon;

        public ExplorerFileIcon(FileViewModel viewModel, IExplorerIconsProvider iconsProvider)
        {
            _viewModel = viewModel;
            _iconsProvider = iconsProvider;
        }

        public async Task EnsureLoadedAsync()
        {
            if (IsPreviewImage())
            {
                _fileIcon = await LoadPreviewIconAsync();
            }
            else
            {
                _fileIcon = await _iconsProvider.GetIconAsync(_viewModel.Extension);
            }
        }

        public Sprite GetIcon()
        {
            return _fileIcon;
        }

        public void Dispose()
        {
            if (IsPreviewImage())
            {
                _fileIcon.Dispose();
                _fileIcon = null;
            }
        }

        private async Task<Sprite> LoadPreviewIconAsync()
        {
            var textureBytes = await File.ReadAllBytesAsync(_viewModel.Path);
            return textureBytes.CreateSpriteFromBytes();
        }

        private bool IsPreviewImage()
        {
            return _viewModel.IsImage() && _iconsProvider.IsPreviewImagesInsteadOfIcons;
        }
    }
}