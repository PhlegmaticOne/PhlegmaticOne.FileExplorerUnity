using System.Threading.Tasks;
using PhlegmaticOne.FileExplorer.Core.FileEntries.ViewModels;
using PhlegmaticOne.FileExplorer.Features.Actions.Properties.Views;
using PhlegmaticOne.FileExplorer.Infrastructure.Popups;

namespace PhlegmaticOne.FileExplorer.Features.Actions.Properties.Services
{
    internal sealed class FileEntryPropertiesViewProvider : IFileEntryPropertiesViewProvider
    {
        private readonly IPopupProvider _popupProvider;

        public FileEntryPropertiesViewProvider(IPopupProvider popupProvider)
        {
            _popupProvider = popupProvider;
        }
        
        public Task ViewFileProperties(FileEntryViewModel viewModel)
        {
            var properties = viewModel.GetProperties();
            var propertiesViewModel = new PropertiesPopupViewModel(properties);
            return _popupProvider.Show<PropertiesPopup, PropertiesPopupViewModel>(propertiesViewModel);
        }
    }
}