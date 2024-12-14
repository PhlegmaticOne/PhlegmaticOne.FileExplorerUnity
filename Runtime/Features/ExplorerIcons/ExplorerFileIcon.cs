using System.IO;
using System.Threading;
using System.Threading.Tasks;
using PhlegmaticOne.FileExplorer.Core.FileEntries.ViewModels.Files;
using PhlegmaticOne.FileExplorer.Features.ExplorerIcons.Services;
using PhlegmaticOne.FileExplorer.Infrastructure.Extensions;
using UnityEngine;

namespace PhlegmaticOne.FileExplorer.Features.ExplorerIcons
{
    internal sealed class ExplorerFileIcon
    {
        private const string NoneExtension = "none";
        
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
                var extension = string.IsNullOrEmpty(_viewModel.Extension) ? NoneExtension : _viewModel.Extension;
                _fileIcon = await _iconsProvider.GetIconAsync(extension, cancellationToken);
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
            return _viewModel.IsImage() && _iconsProvider.IsPreviewImagesInsteadOfIcons;
        }
    }
}