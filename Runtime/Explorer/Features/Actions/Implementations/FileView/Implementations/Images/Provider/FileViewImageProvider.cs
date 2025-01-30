using System.Threading;
using System.Threading.Tasks;
using PhlegmaticOne.FileExplorer.Features.Actions.Implementations.FileView.ViewModels;
using PhlegmaticOne.FileExplorer.Features.Actions.Implementations.FileView.Views;
using PhlegmaticOne.FileExplorer.Features.FileEntries.ViewModels;
using PhlegmaticOne.FileExplorer.Infrastructure.Popups;

namespace PhlegmaticOne.FileExplorer.Features.Actions.Implementations.FileView.Implementations
{
    internal sealed class FileViewImageProvider : IFileViewImageProvider
    {
        private readonly IPopupProvider _popupProvider;
        private readonly IFileImageLoader _imageLoader;

        public FileViewImageProvider(
            IPopupProvider popupProvider,
            IFileImageLoader imageLoader)
        {
            _popupProvider = popupProvider;
            _imageLoader = imageLoader;
        }
        
        public async Task ViewImageAsync(FileEntryViewModel file, CancellationToken token)
        {
            var imageContent = await _imageLoader.GetImage(file, token);
            var viewModel = FileViewViewModel.Image(imageContent);
            await _popupProvider.Show<FileViewPopup, FileViewViewModel>(viewModel);
        }
    }
}