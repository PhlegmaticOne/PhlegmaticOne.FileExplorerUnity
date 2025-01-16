using System.Collections.Generic;
using System.Threading.Tasks;
using PhlegmaticOne.FileExplorer.Features.Actions.Implementations.Properties;
using PhlegmaticOne.FileExplorer.Features.Actions.Implementations.Properties.Views;
using PhlegmaticOne.FileExplorer.Features.Actions.ViewModels;
using PhlegmaticOne.FileExplorer.Features.FileEntries.Services.Actions;
using PhlegmaticOne.FileExplorer.Features.Selection.Services;
using PhlegmaticOne.FileExplorer.Infrastructure.Popups;

namespace PhlegmaticOne.FileExplorer.Features.Selection.Actions
{
    internal sealed class ActionSelectionProperties : ActionViewModel
    {
        private readonly IPopupProvider _popupProvider;
        private readonly ISelectionPropertiesProvider _selectionPropertiesProvider;

        public ActionSelectionProperties(
            IPopupProvider popupProvider,
            ISelectionPropertiesProvider selectionPropertiesProvider,
            ActionsViewModel actionsViewModel) : base(actionsViewModel)
        {
            _popupProvider = popupProvider;
            _selectionPropertiesProvider = selectionPropertiesProvider;
        }

        public override string Description => "Properties";
        
        public override ActionColor Color => ActionColor.Auto;
        
        protected override async Task<bool> ExecuteAction()
        {
            var selectionProperties = _selectionPropertiesProvider.GetSelectionProperties();
            
            var properties = new Dictionary<string, string>
            {
                { "Selection", GetSelectionView(selectionProperties.EntriesCounter) },
                { "Size", selectionProperties.SelectionSize.BuildUnitView() }
            };
            
            var propertiesViewModel = new PropertiesPopupViewModel(properties);
            await _popupProvider.Show<PropertiesPopup, PropertiesPopupViewModel>(propertiesViewModel);
            return true;
        }

        private string GetSelectionView(FileEntriesCounter count)
        {
            return $"Files: {count.FilesCount}, Directories: {count.DirectoriesCount}";
        }
    }
}