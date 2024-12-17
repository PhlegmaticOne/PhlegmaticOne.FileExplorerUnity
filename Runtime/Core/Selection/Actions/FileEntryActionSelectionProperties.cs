using System.Collections.Generic;
using System.Threading.Tasks;
using PhlegmaticOne.FileExplorer.Core.Actions.ViewModels;
using PhlegmaticOne.FileExplorer.Core.Selection.ViewModels;
using PhlegmaticOne.FileExplorer.Features.Actions;
using PhlegmaticOne.FileExplorer.Features.Actions.Properties.Core;
using PhlegmaticOne.FileExplorer.Features.Actions.Properties.Views;
using PhlegmaticOne.FileExplorer.Infrastructure.Popups;

namespace PhlegmaticOne.FileExplorer.Core.Selection.Actions
{
    internal sealed class FileEntryActionSelectionProperties : FileEntryAction
    {
        private readonly IPopupProvider _popupProvider;
        private readonly SelectionViewModel _selectionViewModel;

        public FileEntryActionSelectionProperties(
            IPopupProvider popupProvider,
            SelectionViewModel selectionViewModel,
            FileEntryActionsViewModel actionsViewModel) : base(actionsViewModel)
        {
            _popupProvider = popupProvider;
            _selectionViewModel = selectionViewModel;
        }

        public override string Description => "Properties";
        
        public override FileEntryActionColor Color => FileEntryActionColor.Empty;
        
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