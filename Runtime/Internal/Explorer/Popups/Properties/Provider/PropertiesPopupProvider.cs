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
        
        public Task ViewFileProperties(FileEntryViewModel file)
        {
            var properties = file.GetProperties().GetPropertiesView();
            
            var viewModel = _container
                .Instantiate<PropertiesPopupViewModel>()
                .Setup(properties, GetFilePropertiesHeader(file));
            
            return _popupProvider.Show<PropertiesPopup, PropertiesPopupViewModel>(viewModel);
        }

        public Task ViewProperties(IReadOnlyDictionary<string, string> properties, string header)
        {
            var viewModel = _container
                .Instantiate<PropertiesPopupViewModel>()
                .Setup(properties, header);
            
            return _popupProvider.Show<PropertiesPopup, PropertiesPopupViewModel>(viewModel);
        }

        private static string GetFilePropertiesHeader(FileEntryViewModel file)
        {
            var fileType = file.EntryType.ToString();
            return $"{fileType} properties";
        }
    }
}