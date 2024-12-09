using PhlegmaticOne.FileExplorer.Configuration;
using PhlegmaticOne.FileExplorer.Core.Actions.ViewModels;
using PhlegmaticOne.FileExplorer.Core.Explorer.ViewModels;
using PhlegmaticOne.FileExplorer.Core.Explorer.Views;
using PhlegmaticOne.FileExplorer.Core.Navigation.ViewModels;
using PhlegmaticOne.FileExplorer.Features.Cancellation;
using PhlegmaticOne.FileExplorer.Features.ExplorerIcons.Services;
using PhlegmaticOne.FileExplorer.Features.ExplorerIcons.WebLoading;
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
            var camera = Camera.main;
            
            var iconsLoader = new ExplorerIconsLoader(new WebFileLoader());
            var cancellationProvider = new ExplorerCancellationProvider();
            var iconsProvider = new ExplorerIconsProvider(iconsLoader, config);
            var actionsViewModel = new FileEntryActionsViewModel();
            var fileEntryFactory = new FileEntryFactory(iconsProvider, actionsViewModel, camera);
            var navigator = new ExplorerNavigator(fileEntryFactory);
            var navigationViewModel = new NavigationViewModel(
                navigator, cancellationProvider, actionsViewModel, config);
            var explorerViewModel = new FileExplorerViewModel(
                cancellationProvider, iconsProvider, navigationViewModel, actionsViewModel);
            
            fileEntryFactory.SetupNavigation(navigationViewModel);

            var explorer = Object.Instantiate(explorerPrefab);
            explorer.Bind(explorerViewModel);
        }
    }
}