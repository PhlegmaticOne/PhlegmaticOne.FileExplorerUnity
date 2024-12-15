using System.IO;
using PhlegmaticOne.FileExplorer.Core.Actions.ViewModels;
using PhlegmaticOne.FileExplorer.Core.FileEntries.ViewModels;
using PhlegmaticOne.FileExplorer.Core.FileEntries.ViewModels.Directories;
using PhlegmaticOne.FileExplorer.Core.FileEntries.ViewModels.Files;
using PhlegmaticOne.FileExplorer.Core.Navigation.ViewModels;
using PhlegmaticOne.FileExplorer.Features.Actions;
using PhlegmaticOne.FileExplorer.Features.ExplorerIcons.Services;
using PhlegmaticOne.FileExplorer.Features.FileOperations;
using PhlegmaticOne.FileExplorer.Infrastructure.DependencyInjection;

namespace PhlegmaticOne.FileExplorer.Features.Navigation
{
    internal sealed class FileEntryFactory : IFileEntryFactory
    {
        private readonly IExplorerIconsProvider _iconsProvider;
        private readonly IDependencyContainer _dependencyContainer;
        private readonly FileEntryActionsViewModel _actionsViewModel;
        private readonly IFileOperations _fileOperations;

        public FileEntryFactory(
            IExplorerIconsProvider iconsProvider,
            IDependencyContainer dependencyContainer,
            FileEntryActionsViewModel actionsViewModel,
            IFileOperations fileOperations)
        {
            _iconsProvider = iconsProvider;
            _dependencyContainer = dependencyContainer;
            _actionsViewModel = actionsViewModel;
            _fileOperations = fileOperations;
        }
        
        public FileEntryViewModel CreateEntry(FileSystemInfo fileEntry)
        {
            return File.Exists(fileEntry.FullName) 
                ? CreateFileEntry(fileEntry) 
                : CreateDirectoryEntry(fileEntry);
        }

        private FileEntryViewModel CreateFileEntry(FileSystemInfo fileInfo)
        {
            var actions = _dependencyContainer.Resolve<FileEntryActionsFactoryFile>();
            var actionsProvider = new FileEntryActionsProvider(_actionsViewModel, actions);
            
            return new FileViewModel(
                fileInfo.FullName, fileInfo.Name, fileInfo.Extension,
                _iconsProvider, actionsProvider, _fileOperations);
        }

        private FileEntryViewModel CreateDirectoryEntry(FileSystemInfo fileInfo)
        {
            var actions = _dependencyContainer.Resolve<FileEntryActionsFactoryDirectory>();
            var navigation = _dependencyContainer.Resolve<NavigationViewModel>();
            var actionsProvider = new FileEntryActionsProvider(_actionsViewModel, actions);
            
            return new DirectoryViewModel(
                fileInfo.FullName, fileInfo.Name,
                _iconsProvider, actionsProvider, navigation, _fileOperations);
        }
    }
}