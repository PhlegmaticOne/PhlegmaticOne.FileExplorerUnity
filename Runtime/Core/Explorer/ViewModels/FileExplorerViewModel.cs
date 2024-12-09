using PhlegmaticOne.FileExplorer.Core.Actions.ViewModels;
using PhlegmaticOne.FileExplorer.Core.Navigation.ViewModels;
using PhlegmaticOne.FileExplorer.Features.Cancellation;
using PhlegmaticOne.FileExplorer.Features.ExplorerIcons.Services;

namespace PhlegmaticOne.FileExplorer.Core.Explorer.ViewModels
{
    internal sealed class FileExplorerViewModel
    {
        private readonly IExplorerCancellationProvider _cancellationProvider;
        private readonly IExplorerIconsProvider _iconsProvider;

        public FileExplorerViewModel(
            IExplorerCancellationProvider cancellationProvider,
            IExplorerIconsProvider iconsProvider,
            NavigationViewModel navigationViewModel,
            FileEntryActionsViewModel actionsViewModel)
        {
            NavigationViewModel = navigationViewModel;
            ActionsViewModel = actionsViewModel;
            _cancellationProvider = cancellationProvider;
            _iconsProvider = iconsProvider;
        }

        public NavigationViewModel NavigationViewModel { get; }
        public FileEntryActionsViewModel ActionsViewModel { get; }

        public void OnClosing()
        {
            _cancellationProvider.Cancel();
            ActionsViewModel.Deactivate();
            NavigationViewModel.ClearEntries();
            _iconsProvider.Dispose();
        }
    }
}