using PhlegmaticOne.FileExplorer.Features.Actions.Services.Positioning;
using PhlegmaticOne.FileExplorer.Features.Selection.Entities;
using PhlegmaticOne.FileExplorer.Services.ShowConfiguration;

namespace PhlegmaticOne.FileExplorer.Features.FileEntries.Entities.Files.Commands
{
    internal sealed class FileViewModelClickCommandSelection : IFileViewModelClickCommand
    {
        private readonly SelectionViewModel _selectionViewModel;
        private readonly IExplorerShowConfiguration _showConfiguration;

        public FileViewModelClickCommandSelection(
            SelectionViewModel selectionViewModel,
            IExplorerShowConfiguration showConfiguration)
        {
            _selectionViewModel = selectionViewModel;
            _showConfiguration = showConfiguration;
        }
        
        public void OnClick(FileViewModel file, ActionTargetViewPosition position)
        {
            if (_showConfiguration.IsSelectSingleFile())
            {
                _selectionViewModel.Clear();
                _selectionViewModel.UpdateSelection(file);
                return;
            }

            if (_showConfiguration.IsSelectMultipleFiles())
            {
                _selectionViewModel.UpdateSelection(file);
            }
        }
    }
}