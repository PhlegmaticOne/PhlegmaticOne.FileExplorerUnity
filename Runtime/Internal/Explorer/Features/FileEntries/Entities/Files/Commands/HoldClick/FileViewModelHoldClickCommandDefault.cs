using PhlegmaticOne.FileExplorer.Features.Selection.Entities;

namespace PhlegmaticOne.FileExplorer.Features.FileEntries.Entities.Files.Commands
{
    internal class FileViewModelHoldClickCommandDefault : IFileViewModelHoldClickCommand
    {
        private readonly SelectionViewModel _selectionViewModel;

        public FileViewModelHoldClickCommandDefault(
            SelectionViewModel selectionViewModel)
        {
            _selectionViewModel = selectionViewModel;
        }
        
        public void OnHoldClick(FileViewModel file)
        {
            if (!_selectionViewModel.IsSelectionActive)
            {
                _selectionViewModel.UpdateSelection(file);
            }
        }
    }
}