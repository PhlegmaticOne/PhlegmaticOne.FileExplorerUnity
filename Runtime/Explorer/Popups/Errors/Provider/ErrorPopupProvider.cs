using System;
using System.Threading.Tasks;
using PhlegmaticOne.FileExplorer.Features.FileEntries.Entities;
using PhlegmaticOne.FileExplorer.Infrastructure.DependencyInjection;
using PhlegmaticOne.FileExplorer.Infrastructure.Popups;

namespace PhlegmaticOne.FileExplorer.Popups.Errors
{
    internal sealed class ErrorPopupProvider : IErrorPopupProvider
    {
        private readonly IDependencyContainer _container;
        private readonly IPopupProvider _popupProvider;

        public ErrorPopupProvider(IDependencyContainer container, IPopupProvider popupProvider)
        {
            _container = container;
            _popupProvider = popupProvider;
        }
        
        public Task ViewError(FileEntryViewModel fileEntry, Exception exception)
        {
            var viewModel = _container
                .Instantiate<ErrorPopupViewModel>()
                .SetTitle($"{fileEntry.Name} ({fileEntry.EntryType})")
                .SetErrorFromException(exception);
            
            return _popupProvider.Show<ErrorPopup, ErrorPopupViewModel>(viewModel);
        }

        public Task ViewError(Exception exception)
        {
            var viewModel = _container
                .Instantiate<ErrorPopupViewModel>()
                .SetTitle("Exception occured")
                .SetErrorFromException(exception);
            
            return _popupProvider.Show<ErrorPopup, ErrorPopupViewModel>(viewModel);
        }
    }
}