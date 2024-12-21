using PhlegmaticOne.FileExplorer.Configuration;
using PhlegmaticOne.FileExplorer.Core.Actions.ViewModels;
using PhlegmaticOne.FileExplorer.Core.Explorer.ViewModels;
using PhlegmaticOne.FileExplorer.Core.Explorer.Views;
using PhlegmaticOne.FileExplorer.Core.FileEntries.ViewModels.Directories;
using PhlegmaticOne.FileExplorer.Core.FileEntries.ViewModels.Files;
using PhlegmaticOne.FileExplorer.Core.FileEntries.ViewModels.Files.Extensions;
using PhlegmaticOne.FileExplorer.Core.Navigation.ViewModels;
using PhlegmaticOne.FileExplorer.Core.Path.Services;
using PhlegmaticOne.FileExplorer.Core.Path.ViewModels;
using PhlegmaticOne.FileExplorer.Core.ScreenMessages.ViewModels;
using PhlegmaticOne.FileExplorer.Core.Searching.Services;
using PhlegmaticOne.FileExplorer.Core.Searching.ViewModels;
using PhlegmaticOne.FileExplorer.Core.Selection.Services;
using PhlegmaticOne.FileExplorer.Core.Selection.ViewModels;
using PhlegmaticOne.FileExplorer.Core.Tab.ViewModels;
using PhlegmaticOne.FileExplorer.Features.Actions;
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
            container.Register<IFileActionViewPositionCalculator, FileActionViewPositionCalculator>();
            container.Register<IFileOperations, FileOperations>();
            container.Register<IFileExtensions, FileExtensions>();
            container.Register<IFileEntryFinder, FileEntryFinder>();
            
            container.Register<IPathPartFactory, PathPartFactory>();
            container.Register<IPathParser, PathParser>();
            container.Register<IPathBuilder, PathBuilder>();
            
            container.Register<IFileEntryRenameDataProvider, FileEntryRenameDataProvider>();
            container.Register<IFileEntryPropertiesViewProvider, FileEntryPropertiesViewProvider>();
            container.Register<ISelectionActionsProvider, SelectionActionsProvider>();
            container.Register<IFileViewProvider, FileViewProvider>();

            container.Register<IFileEntryActionsFactory, FileEntryActionsFactoryFile>();
            container.Register<IFileEntryActionsFactory, FileEntryActionsFactoryDirectory>();
            container.Register<IFileEntryActionsProvider, FileEntryActionsProvider>();
            container.Register<IFileEntryFactory, FileEntryFactory>();
            container.Register<IExplorerNavigator, ExplorerNavigator>();
            
            container.RegisterSelf<FileEntryActionsViewModel>();
            container.RegisterSelf<TabViewModel>();
            container.RegisterSelf<SelectionViewModel>();
            container.RegisterSelf<SearchViewModel>();
            container.RegisterSelf<ScreenMessagesViewModel>();
            container.RegisterSelf<NavigationViewModel>();
            container.RegisterSelf<PathViewModel>();
            container.RegisterSelf<FileExplorerViewModel>();
            
            explorer.Bind(container.Resolve<FileExplorerViewModel>());
        }
    }
}