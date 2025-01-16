using System.IO;
using System.Threading;
using System.Threading.Tasks;
using PhlegmaticOne.FileExplorer.Features.FileEntries.Services.Icons.Services;
using PhlegmaticOne.FileExplorer.Features.FileEntries.ViewModels.Files;
using PhlegmaticOne.FileExplorer.Infrastructure.Extensions;
using UnityEngine;

namespace PhlegmaticOne.FileExplorer.Features.FileEntries.Services.Icons
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

        public async Task EnsureLoadedAsync(CancellationToken cancellationToken)
        {
            if (IsPreviewImage())
            {
                _fileIcon = await LoadPreviewIconAsync(cancellationToken);
            }
            else
            {
                var fileExtension = _viewModel.Extension;
                _fileIcon = await _iconsProvider.GetIconAsync(fileExtension.Value, cancellationToken);
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

        private async Task<Sprite> LoadPreviewIconAsync(CancellationToken cancellationToken)
        {
            var textureBytes = await File.ReadAllBytesAsync(_viewModel.Path, cancellationToken);
            return textureBytes.CreateSpriteFromBytes();
        }

        private bool IsPreviewImage()
        {
            return _viewModel.Extension.IsImage() && _iconsProvider.IsPreviewImagesInsteadOfIcons;
        }
    }
}