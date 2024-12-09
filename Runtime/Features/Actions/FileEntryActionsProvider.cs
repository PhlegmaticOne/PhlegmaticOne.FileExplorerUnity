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

        public void ShowActions(FileEntryViewModel fileEntry)
        {
            var actions = _actionsFactory.GetActions(fileEntry);
            _viewModel.ShowActions(actions, fileEntry.Position);
        }
    }
}