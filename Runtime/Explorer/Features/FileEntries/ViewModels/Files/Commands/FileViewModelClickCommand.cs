﻿using PhlegmaticOne.FileExplorer.Features.FileEntries.Services.Actions;
using PhlegmaticOne.FileExplorer.Features.FileEntries.ViewModels.Files.Actions;
using PhlegmaticOne.FileExplorer.Features.Selection.ViewModels;

namespace PhlegmaticOne.FileExplorer.Features.FileEntries.ViewModels.Files.Commands
{
    internal sealed class FileViewModelClickCommand : IFileViewModelClickCommand
    {
        private readonly SelectionViewModel _selectionViewModel;
        private readonly IFileEntryShowActionsProvider _showActionsProvider;
        private readonly IFileConfidentActionProvider _confidentActionProvider;

        public FileViewModelClickCommand(
            SelectionViewModel selectionViewModel,
            IFileEntryShowActionsProvider showActionsProvider,
            IFileConfidentActionProvider confidentActionProvider)
        {
            _selectionViewModel = selectionViewModel;
            _showActionsProvider = showActionsProvider;
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
                action.ExecuteCommand.Execute(null);
                return;
            }
            
            _showActionsProvider.ShowActions(fileViewModel);
        }
    }
}