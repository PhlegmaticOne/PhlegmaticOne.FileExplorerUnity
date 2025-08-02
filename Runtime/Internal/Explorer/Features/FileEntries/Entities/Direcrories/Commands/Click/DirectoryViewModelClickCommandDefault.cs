using PhlegmaticOne.FileExplorer.Features.Actions.Services.Positioning;
using PhlegmaticOne.FileExplorer.Features.FileEntries.Entities.Direcrories;
using PhlegmaticOne.FileExplorer.Features.Navigation.Entities;
using PhlegmaticOne.FileExplorer.Features.Selection.Entities;

namespace PhlegmaticOne.FileExplorer.Features.FileEntries.Entities.Files.Commands
{
    internal sealed class DirectoryViewModelClickCommandDefault : IDirectoryViewModelClickCommand
    {
        private readonly SelectionViewModel _selectionViewModel;
        private readonly NavigationViewModel _navigationViewModel;

        public DirectoryViewModelClickCommandDefault(
            SelectionViewModel selectionViewModel,
            NavigationViewModel navigationViewModel)
        {
            _selectionViewModel = selectionViewModel;
            _navigationViewModel = navigationViewModel;
        }

        public void OnClick(DirectoryViewModel directory, ActionTargetViewPosition position)
        {
            if (_selectionViewModel.IsSelectionActive)
            {
                _selectionViewModel.UpdateSelection(directory);
            }
            else
            {
                _navigationViewModel.Navigate(directory);
            }
        }
    }
}