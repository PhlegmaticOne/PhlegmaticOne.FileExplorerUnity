using System;
using System.Threading.Tasks;
using PhlegmaticOne.FileExplorer.Features.FileEntries.ViewModels;
using PhlegmaticOne.FileExplorer.Infrastructure.Popups;

namespace PhlegmaticOne.FileExplorer.Popups.Errors
{
    internal sealed class ErrorPopupProvider : IErrorPopupProvider
    {
        private readonly IPopupProvider _popupProvider;

        public ErrorPopupProvider(IPopupProvider popupProvider)
        {
            _popupProvider = popupProvider;
        }
        
        public Task ViewError(FileEntryViewModel fileEntry, Exception exception)
        {
            var viewModel = new ErrorPopupViewModel(fileEntry, exception);
            return _popupProvider.Show<ErrorPopup, ErrorPopupViewModel>(viewModel);
        }
    }
}