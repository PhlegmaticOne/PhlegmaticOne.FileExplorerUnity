using PhlegmaticOne.FileExplorer.Features.FileEntries.Core.Actions;
using PhlegmaticOne.FileExplorer.Features.FileEntries.Entities.Direcrories.Actions;
using PhlegmaticOne.FileExplorer.Features.FileEntries.Entities.Files.Actions;
using PhlegmaticOne.FileExplorer.Features.FileEntries.Entities.Files.Commands;
using PhlegmaticOne.FileExplorer.Features.FileEntries.Entities.Files.Extensions;
using PhlegmaticOne.FileExplorer.Features.FileEntries.Factory;
using PhlegmaticOne.FileExplorer.Features.FileEntries.Services.Icons;
using PhlegmaticOne.FileExplorer.Features.FileEntries.Services.Operations;
using PhlegmaticOne.FileExplorer.Features.FileEntries.Services.Scene;
using PhlegmaticOne.FileExplorer.Infrastructure.DependencyInjection;
using PhlegmaticOne.FileExplorer.Infrastructure.DependencyInjection.Installers;
using UnityEngine;
using UnityEngine.UI;

namespace PhlegmaticOne.FileExplorer.Features.FileEntries
{
    internal sealed class FileEntriesInstaller : MonoInstaller
    {
        [SerializeField] private ScrollRect _scrollRect;
        [SerializeField] private RectTransform _headerTransform;
        
        public override void Install(IDependencyContainer container)
        {
            container.Register<IWebFileLoader, WebFileLoader>();
            container.Register<IExplorerIconsLoader, ExplorerIconsLoader>();
            container.Register<IExplorerIconsProvider, ExplorerIconsProvider>();
            
            container.Register<IFileOperations, FileOperations>();
            container.Register<IFileExtensions, FileExtensions>();
            
            container.RegisterInstance(new FileViewSceneService(_scrollRect, _headerTransform));
            
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