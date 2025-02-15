using System.Threading.Tasks;
using PhlegmaticOne.FileExplorer.Features.FileEntries.Entities;
using PhlegmaticOne.FileExplorer.Infrastructure.Popups;

namespace PhlegmaticOne.FileExplorer.Popups.Properties
{
    internal sealed class PropertiesPopupProvider : IPropertiesPopupProvider
    {
        private readonly IPopupProvider _popupProvider;

        public PropertiesPopupProvider(IPopupProvider popupProvider)
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