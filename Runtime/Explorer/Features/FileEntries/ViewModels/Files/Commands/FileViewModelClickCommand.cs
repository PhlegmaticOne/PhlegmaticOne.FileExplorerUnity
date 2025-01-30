using PhlegmaticOne.FileExplorer.Features.FileEntries.Services.Actions;
using PhlegmaticOne.FileExplorer.Features.FileEntries.ViewModels.Files.Actions;
using PhlegmaticOne.FileExplorer.Features.Selection.ViewModels;
using PhlegmaticOne.FileExplorer.Infrastructure.Extensions;

namespace PhlegmaticOne.FileExplorer.Features.FileEntries.ViewModels.Files.Commands
{
    internal sealed class FileViewModelClickCommand : IFileViewModelClickCommand
    {
        private readonly SelectionViewModel _selectionViewModel;
        private readonly IFileEntryActionsProvider _actionsProvider;
        private readonly IFileConfidentActionProvider _confidentActionProvider;

        public FileViewModelClickCommand(
            SelectionViewModel selectionViewModel,
            IFileEntryActionsProvider actionsProvider,
            IFileConfidentActionProvider confidentActionProvider)
        {
            _selectionViewModel = selectionViewModel;
            _actionsProvider = actionsProvider;
            _confidentActionProvider = confidentActionProvider;
        }
        
        public void OnClick(FileViewModel fileViewModel)
        {
            if (_selectionViewModel.IsSelectionActive)
            {
                _selectionViewModel.UpdateSelection(fileViewModel);
                return;
            }

            if (_confidentActionProvider.TryGetConfidentAction(fileViewModel, out var action))
            {
                action.Execute().ForgetUnawareCancellation();
                return;
            }
            
            _actionsProvider.ShowActions(fileViewModel);
        }
    }
}