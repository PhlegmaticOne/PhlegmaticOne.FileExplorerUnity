using System.Threading;
using System.Threading.Tasks;
using PhlegmaticOne.FileExplorer.Features.FileEntries.Entities;
using PhlegmaticOne.FileExplorer.Infrastructure.DependencyInjection;
using PhlegmaticOne.FileExplorer.Infrastructure.Popups;
using PhlegmaticOne.FileExplorer.Services.ContentLoading;

namespace PhlegmaticOne.FileExplorer.Popups.FileView
{
    internal sealed class FileViewTextProvider : IFileViewTextProvider
    {
        private readonly IDependencyContainer _container;
        private readonly IPopupProvider _popupProvider;
        private readonly IFileTextLoader _textLoader;

        public FileViewTextProvider(
            IDependencyContainer container,
            IPopupProvider popupProvider,
            IFileTextLoader textLoader)
        {
            _container = container;
            _popupProvider = popupProvider;
            _textLoader = textLoader;
        }
        
        public async Task ViewTextAsync(FileEntryViewModel file, CancellationToken token)
        {
            var textContent = await _textLoader.GetText(file, token);
            
            var viewModel = _container
                .Instantiate<FileViewViewModel>()
                .SetupText(textContent);
            
            await _popupProvider.Show<FileViewPopup, FileViewViewModel>(viewModel);
        }
    }
}