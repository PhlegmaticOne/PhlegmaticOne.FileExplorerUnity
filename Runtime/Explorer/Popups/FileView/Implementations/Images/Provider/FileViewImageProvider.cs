using System.Threading;
using System.Threading.Tasks;
using PhlegmaticOne.FileExplorer.Features.FileEntries.Entities;
using PhlegmaticOne.FileExplorer.Infrastructure.DependencyInjection;
using PhlegmaticOne.FileExplorer.Infrastructure.Popups;
using PhlegmaticOne.FileExplorer.Services.ContentLoading;

namespace PhlegmaticOne.FileExplorer.Popups.FileView
{
    internal sealed class FileViewImageProvider : IFileViewImageProvider
    {
        private readonly IDependencyContainer _container;
        private readonly IPopupProvider _popupProvider;
        private readonly IFileImageLoader _imageLoader;

        public FileViewImageProvider(
            IDependencyContainer container,
            IPopupProvider popupProvider,
            IFileImageLoader imageLoader)
        {
            _container = container;
            _popupProvider = popupProvider;
            _imageLoader = imageLoader;
        }
        
        public async Task ViewImageAsync(FileEntryViewModel file, CancellationToken token)
        {
            var imageContent = await _imageLoader.GetImage(file, token);
            
            var viewModel = _container
                .Instantiate<FileViewViewModel>()
                .SetupImage(imageContent);
            
            await _popupProvider.Show<FileViewPopup, FileViewViewModel>(viewModel);
        }
    }
}