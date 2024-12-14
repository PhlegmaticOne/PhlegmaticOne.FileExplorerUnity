using PhlegmaticOne.FileExplorer.Core.Actions.ViewModels;
using PhlegmaticOne.FileExplorer.Core.Navigation.ViewModels;
using PhlegmaticOne.FileExplorer.Core.Tab.ViewModels;
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
            FileEntryActionsViewModel actionsViewModel, 
            TabViewModel tabViewModel)
        {
            NavigationViewModel = navigationViewModel;
            ActionsViewModel = actionsViewModel;
            TabViewModel = tabViewModel;
            _cancellationProvider = cancellationProvider;
            _iconsProvider = iconsProvider;
        }

        public NavigationViewModel NavigationViewModel { get; }
        public FileEntryActionsViewModel ActionsViewModel { get; }
        public TabViewModel TabViewModel { get; }

        public void NavigateRoot()
        {
            NavigationViewModel.NavigateRoot();
        }

        public void OnClosing()
        {
            _cancellationProvider.Cancel();
            ActionsViewModel.Deactivate();
            TabViewModel.Clear();
            _iconsProvider.Dispose();
        }
    }
}