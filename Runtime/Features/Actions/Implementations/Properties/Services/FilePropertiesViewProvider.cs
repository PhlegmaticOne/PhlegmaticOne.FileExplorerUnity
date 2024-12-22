using System.Threading.Tasks;
using PhlegmaticOne.FileExplorer.Features.Actions.Implementations.Properties.Views;
using PhlegmaticOne.FileExplorer.Features.FileEntries.ViewModels;
using PhlegmaticOne.FileExplorer.Infrastructure.Popups;

namespace PhlegmaticOne.FileExplorer.Features.Actions.Implementations.Properties.Services
{
    internal sealed class FilePropertiesViewProvider : IFilePropertiesViewProvider
    {
        private readonly IPopupProvider _popupProvider;

        public FilePropertiesViewProvider(IPopupProvider popupProvider)
        {
            _popupProvider = popupProvider;
        }
        
        public Task ViewFileProperties(FileEntryViewModel viewModel)
        {
            var properties = viewModel.GetProperties().GetPropertiesView();
            var propertiesViewModel = new PropertiesPopupViewModel(properties);
            return _popupProvider.Show<PropertiesPopup, PropertiesPopupViewModel>(propertiesViewModel);
        }
    }
}