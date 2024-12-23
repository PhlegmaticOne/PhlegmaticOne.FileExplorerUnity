using System.Collections.Generic;
using System.Threading.Tasks;
using PhlegmaticOne.FileExplorer.Features.Actions.Implementations.Properties.Core;
using PhlegmaticOne.FileExplorer.Features.Actions.Implementations.Properties.Views;
using PhlegmaticOne.FileExplorer.Features.Actions.ViewModels;
using PhlegmaticOne.FileExplorer.Features.Selection.ViewModels;
using PhlegmaticOne.FileExplorer.Infrastructure.Popups;

namespace PhlegmaticOne.FileExplorer.Features.Selection.Actions
{
    internal sealed class FileEntryActionSelectionProperties : ActionViewModel
    {
        private readonly IPopupProvider _popupProvider;
        private readonly SelectionViewModel _selectionViewModel;

        public FileEntryActionSelectionProperties(
            IPopupProvider popupProvider,
            SelectionViewModel selectionViewModel,
            ActionsViewModel actionsViewModel) : base(actionsViewModel)
        {
            _popupProvider = popupProvider;
            _selectionViewModel = selectionViewModel;
        }

        public override string Description => "Properties";
        
        public override ActionColor Color => ActionColor.Auto;
        
        protected override async Task<bool> ExecuteAction()
        {
            var properties = new Dictionary<string, string>
            {
                { "Selection", GetSelectionView() },
                { "Size", GetMergedSizeView() }
            };
            
            var propertiesViewModel = new PropertiesPopupViewModel(properties);
            await _popupProvider.Show<PropertiesPopup, PropertiesPopupViewModel>(propertiesViewModel);
            return true;
        }

        private string GetMergedSizeView()
        {
            var size = FileSize.Zero;

            foreach (var fileEntry in _selectionViewModel.GetSelection())
            {
                var properties = fileEntry.GetProperties();
                size.Merge(properties.Size);
            }

            return size.BuildUnitView();
        }

        private string GetSelectionView()
        {
            var count = _selectionViewModel.SelectedEntriesCount.Value;
            return $"Files: {count.FilesCount}, Directories: {count.DirectoriesCount}";
        }
    }
}