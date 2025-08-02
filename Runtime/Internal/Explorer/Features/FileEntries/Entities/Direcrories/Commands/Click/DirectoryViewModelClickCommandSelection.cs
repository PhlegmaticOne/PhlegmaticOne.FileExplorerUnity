using PhlegmaticOne.FileExplorer.Features.Actions.Services.Positioning;
using PhlegmaticOne.FileExplorer.Features.FileEntries.Entities.Direcrories;
using PhlegmaticOne.FileExplorer.Features.Navigation.Entities;
using PhlegmaticOne.FileExplorer.Features.Selection.Entities;
using PhlegmaticOne.FileExplorer.Services.ShowConfiguration;

namespace PhlegmaticOne.FileExplorer.Features.FileEntries.Entities.Files.Commands
{
    internal sealed class DirectoryViewModelClickCommandSelection : IDirectoryViewModelClickCommand
    {
        private readonly SelectionViewModel _selectionViewModel;
        private readonly NavigationViewModel _navigationViewModel;
        private readonly IExplorerShowConfiguration _showConfiguration;

        public DirectoryViewModelClickCommandSelection(
            SelectionViewModel selectionViewModel,
            NavigationViewModel navigationViewModel,
            IExplorerShowConfiguration showConfiguration)
        {
            _selectionViewModel = selectionViewModel;
            _navigationViewModel = navigationViewModel;
            _showConfiguration = showConfiguration;
        }

        public void OnClick(DirectoryViewModel directory, ActionTargetViewPosition position)
        {
            if (!_selectionViewModel.IsSelectionActive)
            {
                _navigationViewModel.Navigate(directory);
                return;
            }

            if (!_showConfiguration.CanSelectDirectories())
            {
                return;
            }
            
            if (_showConfiguration.IsSelectSingleFile())
            {
                _selectionViewModel.Clear();
                _selectionViewModel.UpdateSelection(directory);
                return;
            }

            if (_showConfiguration.IsSelectMultipleFiles())
            {
                _selectionViewModel.UpdateSelection(directory);
            }
        }
    }
}