using PhlegmaticOne.FileExplorer.Core.Actions.ViewModels;
using PhlegmaticOne.FileExplorer.Core.FileEntries.ViewModels;

namespace PhlegmaticOne.FileExplorer.Features.Actions
{
    internal sealed class FileEntryActionsProvider
    {
        private readonly FileEntryActionsViewModel _viewModel;
        private readonly IFileEntryActionsFactory _actionsFactory;

        public FileEntryActionsProvider(
            FileEntryActionsViewModel viewModel,
            IFileEntryActionsFactory actionsFactory)
        {
            _viewModel = viewModel;
            _actionsFactory = actionsFactory;
        }

        public void ShowActions(FileEntryViewModel file)
        {
            var actions = _actionsFactory.GetActions(file);
            var actionPosition = file.Position.ToActionViewPositionData(FileActionViewAlignment.DockToTargetCenter);
            _viewModel.ShowActions(actions, actionPosition);
        }
    }
}