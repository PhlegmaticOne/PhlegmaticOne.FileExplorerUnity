using System.Threading;
using System.Threading.Tasks;
using PhlegmaticOne.FileExplorer.Features.FileEntries.ViewModels;
using PhlegmaticOne.FileExplorer.Infrastructure.Popups;

namespace PhlegmaticOne.FileExplorer.Popups.FileView
{
    internal sealed class FileViewTextProvider : IFileViewTextProvider
    {
        private readonly IPopupProvider _popupProvider;
        private readonly IFileTextLoader _textLoader;

        public FileViewTextProvider(
            IPopupProvider popupProvider,
            IFileTextLoader textLoader)
        {
            _popupProvider = popupProvider;
            _textLoader = textLoader;
        }
        
        public async Task ViewTextAsync(FileEntryViewModel file, CancellationToken token)
        {
            var textContent = await _textLoader.GetText(file, token);
            var viewModel = FileViewViewModel.Text(textContent);
            await _popupProvider.Show<FileViewPopup, FileViewViewModel>(viewModel);
        }
    }
}