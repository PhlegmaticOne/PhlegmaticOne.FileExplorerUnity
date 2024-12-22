using System.Threading.Tasks;
using PhlegmaticOne.FileExplorer.Features.Actions.Implementations.FileView.Core;
using PhlegmaticOne.FileExplorer.Features.Actions.Implementations.FileView.ViewModels;
using PhlegmaticOne.FileExplorer.Features.Actions.Implementations.FileView.Views;
using PhlegmaticOne.FileExplorer.Features.FileEntries.ViewModels.Files;
using PhlegmaticOne.FileExplorer.Infrastructure.Popups;

namespace PhlegmaticOne.FileExplorer.Features.Actions.Implementations.FileView.Services
{
    internal sealed class FileViewContentProvider : IFileViewContentProvider
    {
        private readonly IPopupProvider _popupProvider;

        public FileViewContentProvider(IPopupProvider popupProvider)
        {
            _popupProvider = popupProvider;
        }
        
        public Task ViewFileAsync(FileViewModel viewModel, FileViewType viewType)
        {
            var fileViewViewModel = new FileViewViewModel(viewModel, viewType);
            return _popupProvider.Show<FileViewPopup, FileViewViewModel>(fileViewViewModel);
        }
    }
}