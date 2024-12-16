using PhlegmaticOne.FileExplorer.Core.Actions.ViewModels;
using PhlegmaticOne.FileExplorer.Core.FileEntries.ViewModels;

namespace PhlegmaticOne.FileExplorer.Features.Actions
{
    internal sealed class FileEntryActionsProvider<T> : IFileEntryActionsProvider where T : IFileEntryActionsFactory
    {
        private readonly FileEntryActionsViewModel _viewModel;
        private readonly T _actionsFactory;

        public FileEntryActionsProvider(
            FileEntryActionsViewModel viewModel,
            T actionsFactory)
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