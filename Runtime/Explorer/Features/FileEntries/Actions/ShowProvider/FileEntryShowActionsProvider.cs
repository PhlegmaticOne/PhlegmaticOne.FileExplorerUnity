using System;
using PhlegmaticOne.FileExplorer.Features.Actions.Services.Positioning;
using PhlegmaticOne.FileExplorer.Features.Actions.ViewModels;
using PhlegmaticOne.FileExplorer.Features.FileEntries.ViewModels;

namespace PhlegmaticOne.FileExplorer.Features.FileEntries.Services.Actions
{
    internal sealed class FileEntryShowActionsProvider : IFileEntryShowActionsProvider
    {
        private readonly ActionsViewModel _viewModel;
        private readonly IFileEntryShowActionsFactory[] _actionsFactory;

        public FileEntryShowActionsProvider(
            ActionsViewModel viewModel,
            IFileEntryShowActionsFactory[] actionsFactory)
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
            _viewModel.SetActiveEntry(fileEntry);
        }
    }
}