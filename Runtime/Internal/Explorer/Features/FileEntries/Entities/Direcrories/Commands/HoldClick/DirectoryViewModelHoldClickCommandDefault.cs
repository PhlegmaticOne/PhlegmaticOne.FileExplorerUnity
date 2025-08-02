using PhlegmaticOne.FileExplorer.Features.FileEntries.Entities.Direcrories;
using PhlegmaticOne.FileExplorer.Features.Selection.Entities;
using PhlegmaticOne.FileExplorer.Services.ShowConfiguration;

namespace PhlegmaticOne.FileExplorer.Features.FileEntries.Entities.Files.Commands
{
    internal class DirectoryViewModelHoldClickCommandDefault : IDirectoryViewModelHoldClickCommand
    {
        private readonly SelectionViewModel _selectionViewModel;
        private readonly IExplorerShowConfiguration _showConfiguration;

        public DirectoryViewModelHoldClickCommandDefault(
            SelectionViewModel selectionViewModel,
            IExplorerShowConfiguration showConfiguration)
        {
            _selectionViewModel = selectionViewModel;
            _showConfiguration = showConfiguration;
        }

        public void OnHoldClick(DirectoryViewModel directory)
        {
            if (!_selectionViewModel.IsSelectionActive && _showConfiguration.CanSelectDirectories())
            {
                _selectionViewModel.UpdateSelection(directory);
            }
        }
    }
}