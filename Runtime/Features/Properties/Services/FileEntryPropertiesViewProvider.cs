using System.Threading.Tasks;
using PhlegmaticOne.FileExplorer.Core.FileEntries.ViewModels;
using PhlegmaticOne.FileExplorer.Features.Properties.Views;
using PhlegmaticOne.FileExplorer.Infrastructure.Views;

namespace PhlegmaticOne.FileExplorer.Features.Properties.Services
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
            var propertiesViewModel = new PropertiesViewModel(properties);
            return _popupProvider.Show<PropertiesPopup, PropertiesViewModel>(propertiesViewModel);
        }
    }
}