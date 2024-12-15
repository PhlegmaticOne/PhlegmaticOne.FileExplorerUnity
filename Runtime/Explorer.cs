using PhlegmaticOne.FileExplorer.Configuration;
using PhlegmaticOne.FileExplorer.Core.Actions.ViewModels;
using PhlegmaticOne.FileExplorer.Core.Explorer.ViewModels;
using PhlegmaticOne.FileExplorer.Core.Explorer.Views;
using PhlegmaticOne.FileExplorer.Core.FileEntries.ViewModels.Directories;
using PhlegmaticOne.FileExplorer.Core.FileEntries.ViewModels.Files;
using PhlegmaticOne.FileExplorer.Core.FileEntries.ViewModels.Files.Extensions;
using PhlegmaticOne.FileExplorer.Core.Navigation.ViewModels;
using PhlegmaticOne.FileExplorer.Core.Tab.ViewModels;
using PhlegmaticOne.FileExplorer.Features.Actions.FileView.Services;
using PhlegmaticOne.FileExplorer.Features.Actions.Properties.Services;
using PhlegmaticOne.FileExplorer.Features.Actions.Rename;
using PhlegmaticOne.FileExplorer.Features.Cancellation;
using PhlegmaticOne.FileExplorer.Features.ExplorerIcons.Services;
using PhlegmaticOne.FileExplorer.Features.ExplorerIcons.WebLoading;
using PhlegmaticOne.FileExplorer.Features.FileOperations;
using PhlegmaticOne.FileExplorer.Features.Navigation;
using PhlegmaticOne.FileExplorer.Infrastructure.DependencyInjection;
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

            IDependencyContainer container = new DependencyContainer();
            
            container.RegisterInstance(explorer.PopupProvider);
            container.RegisterInstance(config);
            
            container.Register<IWebFileLoader, WebFileLoader>();
            container.Register<IExplorerIconsLoader, ExplorerIconsLoader>();
            container.Register<IExplorerIconsProvider, ExplorerIconsProvider>();
            container.Register<IExplorerCancellationProvider, ExplorerCancellationProvider>();
            container.Register<IFileOperations, FileOperations>();
            container.Register<IFileExtensions, FileExtensions>();
            
            container.Register<IFileEntryRenameDataProvider, FileEntryRenameDataProvider>();
            container.Register<IFileEntryPropertiesViewProvider, FileEntryPropertiesViewProvider>();
            container.Register<IFileViewProvider, FileViewProvider>();

            container.Register<FileEntryActionsFactoryFile>();
            container.Register<FileEntryActionsFactoryDirectory>();
            container.Register<IFileEntryFactory, FileEntryFactory>();
            container.Register<IExplorerNavigator, ExplorerNavigator>();
            
            container.Register<FileEntryActionsViewModel>();
            container.Register<TabViewModel>();
            container.Register<NavigationViewModel>();
            container.Register<FileExplorerViewModel>();
            
            explorer.Bind(container.Resolve<FileExplorerViewModel>());
        }
    }
}