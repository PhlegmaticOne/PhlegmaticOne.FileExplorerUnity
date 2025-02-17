using System.Collections.Generic;
using System.Threading.Tasks;
using PhlegmaticOne.FileExplorer.Features.FileEntries.Entities;
using PhlegmaticOne.FileExplorer.Infrastructure.DependencyInjection;
using PhlegmaticOne.FileExplorer.Infrastructure.Popups;

namespace PhlegmaticOne.FileExplorer.Popups.Properties
{
    internal sealed class PropertiesPopupProvider : IPropertiesPopupProvider
    {
        private readonly IDependencyContainer _container;
        private readonly IPopupProvider _popupProvider;

        public PropertiesPopupProvider(
            IDependencyContainer container,
            IPopupProvider popupProvider)
        {
            _container = container;
            _popupProvider = popupProvider;
        }
        
        public Task ViewFileProperties(FileEntryViewModel viewModel)
        {
            var properties = viewModel.GetProperties().GetPropertiesView();
            var propertiesViewModel = _container.Instantiate<PropertiesPopupViewModel>();
            propertiesViewModel.Setup(properties, "File properties");
            return _popupProvider.Show<PropertiesPopup, PropertiesPopupViewModel>(propertiesViewModel);
        }

        public Task ViewProperties(IReadOnlyDictionary<string, string> properties, string header)
        {
            var propertiesViewModel = _container.Instantiate<PropertiesPopupViewModel>();
            propertiesViewModel.Setup(properties, header);
            return _popupProvider.Show<PropertiesPopup, PropertiesPopupViewModel>(propertiesViewModel);
        }
    }
}