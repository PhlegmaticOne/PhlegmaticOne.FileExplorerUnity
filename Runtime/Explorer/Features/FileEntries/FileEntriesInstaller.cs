using PhlegmaticOne.FileExplorer.Features.FileEntries.Actions;
using PhlegmaticOne.FileExplorer.Features.FileEntries.Factory;
using PhlegmaticOne.FileExplorer.Features.FileEntries.Services.Actions;
using PhlegmaticOne.FileExplorer.Features.FileEntries.Services.Icons.Services;
using PhlegmaticOne.FileExplorer.Features.FileEntries.Services.Icons.WebLoading;
using PhlegmaticOne.FileExplorer.Features.FileEntries.Services.Operations;
using PhlegmaticOne.FileExplorer.Features.FileEntries.ViewModels.Direcrories.Actions;
using PhlegmaticOne.FileExplorer.Features.FileEntries.ViewModels.Files.Actions;
using PhlegmaticOne.FileExplorer.Features.FileEntries.ViewModels.Files.Commands;
using PhlegmaticOne.FileExplorer.Features.FileEntries.ViewModels.Files.Extensions.Services;
using PhlegmaticOne.FileExplorer.Infrastructure.DependencyInjection;
using PhlegmaticOne.FileExplorer.Infrastructure.DependencyInjection.Installers;

namespace PhlegmaticOne.FileExplorer.Features.FileEntries
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
            
            container.Register<IFileEntryShowActionsFactory, FileEntryShowActionsFactoryFile>();
            container.Register<IFileEntryShowActionsFactory, FileEntryShowActionsFactoryDirectory>();
            container.Register<IFileEntryShowActionsProvider, FileEntryShowActionsProvider>();
            container.Register<IFileConfidentActionProvider, FileConfidentActionProvider>();
            container.Register<IFileEntryFactory, FileEntryFactory>();
            
            container.Register<IFileEntryActionErrorHandler, FileEntryActionErrorHandler>();
            container.Register<IFileEntryActionStartHandler, FileEntryActionStartHandler>();
            container.Register<IFileEntryActionExecuteHandler, FileEntryActionExecuteHandler>();
            container.Register<IFileEntryActionsFactory, FileEntryActionsFactory>();
            
            container.Register<IFileViewModelClickCommand, FileViewModelClickCommand>();
        }
    }
}