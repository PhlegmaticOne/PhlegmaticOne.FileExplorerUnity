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
            var viewModel = _container.Instantiate<ErrorPopupViewModel>();
            
            viewModel.Setup(
                title: $"{fileEntry.Name} ({fileEntry.EntryType})",
                message: exception.Message,
                errorName: exception.GetType().Name);
            
            return _popupProvider.Show<ErrorPopup, ErrorPopupViewModel>(viewModel);
        }

        public Task ViewError(Exception exception)
        {
            var viewModel = _container.Instantiate<ErrorPopupViewModel>();
            
            viewModel.Setup(
                title: "Exception occured",
                message: exception.Message,
                errorName: exception.GetType().Name);
            
            return _popupProvider.Show<ErrorPopup, ErrorPopupViewModel>(viewModel);
        }
    }
}