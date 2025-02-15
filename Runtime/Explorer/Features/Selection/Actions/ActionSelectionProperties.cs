using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using PhlegmaticOne.FileExplorer.Features.Actions.Core;
using PhlegmaticOne.FileExplorer.Features.FileEntries.Services.Proprties;
using PhlegmaticOne.FileExplorer.Features.Selection.Services.Properties;
using PhlegmaticOne.FileExplorer.Infrastructure.Popups;
using PhlegmaticOne.FileExplorer.Popups.Properties;

namespace PhlegmaticOne.FileExplorer.Features.Selection.Actions
{
    internal sealed class ActionSelectionProperties : IAction
    {
        private readonly IPopupProvider _popupProvider;
        private readonly ISelectionPropertiesProvider _selectionPropertiesProvider;

        public ActionSelectionProperties(
            IPopupProvider popupProvider,
            ISelectionPropertiesProvider selectionPropertiesProvider)
        {
            _popupProvider = popupProvider;
            _selectionPropertiesProvider = selectionPropertiesProvider;
        }

        public async Task Execute(CancellationToken token)
        {
            var selectionProperties = _selectionPropertiesProvider.GetSelectionProperties();
            
            var properties = new Dictionary<string, string>
            {
                { "Selection", GetSelectionView(selectionProperties.EntriesCounter) },
                { "Size", selectionProperties.SelectionSize.BuildUnitView() }
            };
            
            var propertiesViewModel = new PropertiesPopupViewModel(properties);
            await _popupProvider.Show<PropertiesPopup, PropertiesPopupViewModel>(propertiesViewModel);
        }

        private static string GetSelectionView(FileEntriesCounter count)
        {
            return $"Files: {count.FilesCount}, Directories: {count.DirectoriesCount}";
        }
    }
}