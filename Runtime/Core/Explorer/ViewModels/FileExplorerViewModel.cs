using PhlegmaticOne.FileExplorer.Core.Actions.ViewModels;
using PhlegmaticOne.FileExplorer.Core.Navigation.ViewModels;
using PhlegmaticOne.FileExplorer.Core.ScreenMessages.Services;
using PhlegmaticOne.FileExplorer.Core.ScreenMessages.ViewModels;
using PhlegmaticOne.FileExplorer.Core.Searching.ViewModels;
using PhlegmaticOne.FileExplorer.Core.Selection.ViewModels;
using PhlegmaticOne.FileExplorer.Core.Tab.ViewModels;
using PhlegmaticOne.FileExplorer.Features.Cancellation;
using PhlegmaticOne.FileExplorer.Features.ExplorerIcons.Services;

namespace PhlegmaticOne.FileExplorer.Core.Explorer.ViewModels
{
    internal sealed class FileExplorerViewModel
    {
        private readonly IExplorerCancellationProvider _cancellationProvider;
        private readonly IExplorerIconsProvider _iconsProvider;
        private readonly ScreenMessageTextChangeListener _textChangeListener;

        public FileExplorerViewModel(
            ScreenMessagesViewModel screenMessagesViewModel,
            IExplorerCancellationProvider cancellationProvider,
            IExplorerIconsProvider iconsProvider,
            NavigationViewModel navigationViewModel,
            FileEntryActionsViewModel actionsViewModel,
            SearchViewModel searchViewModel,
            SelectionViewModel selectionViewModel,
            TabViewModel tabViewModel)
        {
            ScreenMessagesViewModel = screenMessagesViewModel;
            NavigationViewModel = navigationViewModel;
            ActionsViewModel = actionsViewModel;
            SearchViewModel = searchViewModel;
            SelectionViewModel = selectionViewModel;
            TabViewModel = tabViewModel;
            _cancellationProvider = cancellationProvider;
            _iconsProvider = iconsProvider;
            _textChangeListener = new ScreenMessageTextChangeListener(
                screenMessagesViewModel, searchViewModel, tabViewModel);
        }

        public ScreenMessagesViewModel ScreenMessagesViewModel { get; }
        public NavigationViewModel NavigationViewModel { get; }
        public FileEntryActionsViewModel ActionsViewModel { get; }
        public SearchViewModel SearchViewModel { get; }
        public SelectionViewModel SelectionViewModel { get; }
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
            SelectionViewModel.ClearSelection();
            SearchViewModel.Reset();
            _textChangeListener.Release();
            _iconsProvider.Dispose();
        }
    }
}