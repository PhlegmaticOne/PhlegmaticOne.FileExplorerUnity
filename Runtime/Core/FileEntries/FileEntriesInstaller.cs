using PhlegmaticOne.FileExplorer.Core.FileEntries.Factory;
using PhlegmaticOne.FileExplorer.Core.FileEntries.Services;
using PhlegmaticOne.FileExplorer.Core.FileEntries.ViewModels.Directories;
using PhlegmaticOne.FileExplorer.Core.FileEntries.ViewModels.Files;
using PhlegmaticOne.FileExplorer.Core.FileEntries.ViewModels.Files.Extensions;
using PhlegmaticOne.FileExplorer.Features.Actions;
using PhlegmaticOne.FileExplorer.Features.ExplorerIcons.Services;
using PhlegmaticOne.FileExplorer.Features.ExplorerIcons.WebLoading;
using PhlegmaticOne.FileExplorer.Infrastructure.DependencyInjection;
using PhlegmaticOne.FileExplorer.Infrastructure.DependencyInjection.Installers;

namespace PhlegmaticOne.FileExplorer.Core.FileEntries
{
    internal sealed class FileEntriesInstaller : MonoInstaller
    {
        public override void Install(IDependencyContainer container)
        {
            container.Register<IWebFileLoader, WebFileLoader>();
            container.Register<IExplorerIconsLoader, ExplorerIconsLoader>();
            container.Register<IExplorerIconsProvider, ExplorerIconsProvider>();
            
            container.Register<IFileOperations, FileOperations>();
            container.Register<IFileExtensions, FileExtensions>();
            
            container.Register<IFileEntryActionsFactory, FileEntryActionsFactoryFile>();
            container.Register<IFileEntryActionsFactory, FileEntryActionsFactoryDirectory>();
            container.Register<IFileEntryActionsProvider, FileEntryActionsProvider>();
            container.Register<IFileEntryFactory, FileEntryFactory>();
        }
    }
}