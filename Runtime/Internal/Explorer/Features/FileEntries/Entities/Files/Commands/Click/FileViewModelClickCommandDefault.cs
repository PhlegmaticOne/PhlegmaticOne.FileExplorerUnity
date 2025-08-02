using PhlegmaticOne.FileExplorer.Features.Actions.Services.Positioning;
using PhlegmaticOne.FileExplorer.Features.FileEntries.Actions.Core;
using PhlegmaticOne.FileExplorer.Features.FileEntries.Entities.Files.Actions;
using PhlegmaticOne.FileExplorer.Features.Selection.Entities;
using PhlegmaticOne.FileExplorer.Infrastructure.ViewModels.Commands;

namespace PhlegmaticOne.FileExplorer.Features.FileEntries.Entities.Files.Commands
{
    internal sealed class FileViewModelClickCommandDefault : IFileViewModelClickCommand
    {
        private readonly SelectionViewModel _selectionViewModel;
        private readonly IFileEntryShowActionsProvider _showActionsProvider;
        private readonly IFileConfidentActionProvider _confidentActionProvider;

        public FileViewModelClickCommandDefault(
            SelectionViewModel selectionViewModel,
            IFileEntryShowActionsProvider showActionsProvider,
            IFileConfidentActionProvider confidentActionProvider)
        {
            _selectionViewModel = selectionViewModel;
            _showActionsProvider = showActionsProvider;
            _confidentActionProvider = confidentActionProvider;
        }
        
        public void OnClick(FileViewModel file, ActionTargetViewPosition position)
        {
            if (_selectionViewModel.IsSelectionActive)
            {
                _selectionViewModel.UpdateSelection(file);
                return;
            }

            if (_confidentActionProvider.TryGetConfidentAction(file, out var action))
            {
                action.ExecuteCommand.ExecuteWithoutParameter();
                return;
            }
            
            _showActionsProvider.ShowActions(file, position);
        }
    }
}