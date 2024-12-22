using System;
using PhlegmaticOne.FileExplorer.Features.Actions.Services.Positioning;
using PhlegmaticOne.FileExplorer.Features.Actions.ViewModels;
using PhlegmaticOne.FileExplorer.Features.FileEntries.ViewModels;

namespace PhlegmaticOne.FileExplorer.Features.FileEntries.Services.Actions
{
    internal sealed class FileEntryActionsProvider : IFileEntryActionsProvider
    {
        private readonly ActionsViewModel _viewModel;
        private readonly IFileEntryActionsFactory[] _actionsFactory;

        public FileEntryActionsProvider(
            ActionsViewModel viewModel,
            IFileEntryActionsFactory[] actionsFactory)
        {
            _viewModel = viewModel;
            _actionsFactory = actionsFactory;
        }

        public void ShowActions(FileEntryViewModel fileEntry)
        {
            var factory = Array.Find(_actionsFactory, x => x.EntryType == fileEntry.EntryType);
            var actions = factory.GetActions(fileEntry);
            var actionPosition = fileEntry.Position.ToActionViewPositionData(ActionViewAlignment.DockToTargetCenter);
            _viewModel.ShowActions(actions, actionPosition);
        }
    }
}