using PhlegmaticOne.FileExplorer.Features.FileEntries.Entities.Direcrories;
using PhlegmaticOne.FileExplorer.Features.Selection.Entities;

namespace PhlegmaticOne.FileExplorer.Features.FileEntries.Entities.Files.Commands
{
    internal class DirectoryViewModelHoldClickCommandDefault : IDirectoryViewModelHoldClickCommand
    {
        private readonly SelectionViewModel _selectionViewModel;

        public DirectoryViewModelHoldClickCommandDefault(
            SelectionViewModel selectionViewModel)
        {
            _selectionViewModel = selectionViewModel;
        }

        public void OnHoldClick(DirectoryViewModel directory)
        {
            if (!_selectionViewModel.IsSelectionActive)
            {
                _selectionViewModel.UpdateSelection(directory);
            }
        }
    }
}