using System;
using System.Threading.Tasks;
using PhlegmaticOne.FileExplorer.Features.FileEntries.ViewModels;
using PhlegmaticOne.FileExplorer.Infrastructure.Popups;

namespace PhlegmaticOne.FileExplorer.Features.FileEntries.Services.Actions.Handlers.Popups
{
    internal sealed class FileEntryActionErrorViewProvider : IFileEntryActionErrorViewProvider
    {
        private readonly IPopupProvider _popupProvider;

        public FileEntryActionErrorViewProvider(IPopupProvider popupProvider)
        {
            _popupProvider = popupProvider;
        }
        
        public Task ViewError(FileEntryViewModel fileEntry, Exception exception)
        {
            var viewModel = new FileEntryActionErrorPopupViewModel(fileEntry, exception);
            return _popupProvider.Show<FileEntryActionErrorPopup, FileEntryActionErrorPopupViewModel>(viewModel);
        }
    }
}