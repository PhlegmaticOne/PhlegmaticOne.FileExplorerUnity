using PhlegmaticOne.FileExplorer.Configuration;
using PhlegmaticOne.FileExplorer.Core.Actions.ViewModels;
using PhlegmaticOne.FileExplorer.Core.Explorer.ViewModels;
using PhlegmaticOne.FileExplorer.Core.Explorer.Views;
using PhlegmaticOne.FileExplorer.Core.FileEntries.ViewModels.Directories;
using PhlegmaticOne.FileExplorer.Core.FileEntries.ViewModels.Files;
using PhlegmaticOne.FileExplorer.Core.Navigation.ViewModels;
using PhlegmaticOne.FileExplorer.Core.Tab.ViewModels;
using PhlegmaticOne.FileExplorer.Features.Actions;
using PhlegmaticOne.FileExplorer.Features.Actions.Rename;
using PhlegmaticOne.FileExplorer.Features.Cancellation;
using PhlegmaticOne.FileExplorer.Features.ExplorerIcons.Services;
using PhlegmaticOne.FileExplorer.Features.ExplorerIcons.WebLoading;
using PhlegmaticOne.FileExplorer.Features.FileOperations;
using PhlegmaticOne.FileExplorer.Features.Navigation;
using UnityEngine;

namespace PhlegmaticOne.FileExplorer
{
    public class Explorer
    {
        public static void Open()
        {
            var config = Resources.Load<FileExplorerConfig>("Configs/FileExplorerConfig");
            var explorerPrefab = Resources.Load<FileExplorerView>("Prefabs/FileExplorer");
            var explorer = Object.Instantiate(explorerPrefab);

            var popupProvider = explorer.PopupProvider;
            var fileLoader = new WebFileLoader();
            var iconsLoader = new ExplorerIconsLoader(fileLoader);
            var cancellationProvider = new ExplorerCancellationProvider();
            var iconsProvider = new ExplorerIconsProvider(iconsLoader, config);
            var renameDataProvider = new FileRenameDataProvider(popupProvider);
            var fileOperations = new FileOperations();
            
            var actionsViewModel = new FileEntryActionsViewModel();
            var tabViewModel = new TabViewModel();

            var fileActionsProvider = new FileEntryActionsProvider(actionsViewModel,
                new FileEntryActionsFactoryFile(actionsViewModel, renameDataProvider, tabViewModel));
            
            var directoryActionsProvider = new FileEntryActionsProvider(actionsViewModel,
                new FileEntryActionsFactoryDirectory(actionsViewModel, renameDataProvider, tabViewModel));
            
            var fileEntryFactory = new FileEntryFactory(
                iconsProvider, fileActionsProvider, directoryActionsProvider, fileOperations);
            var navigator = new ExplorerNavigator(fileEntryFactory);
            
            var navigationViewModel = new NavigationViewModel(
                navigator, cancellationProvider, actionsViewModel, config, tabViewModel);
            
            var explorerViewModel = new FileExplorerViewModel(
                cancellationProvider, iconsProvider, navigationViewModel, actionsViewModel, tabViewModel);
            
            fileEntryFactory.SetupNavigation(navigationViewModel);

            explorer.Bind(explorerViewModel);
        }
    }
}