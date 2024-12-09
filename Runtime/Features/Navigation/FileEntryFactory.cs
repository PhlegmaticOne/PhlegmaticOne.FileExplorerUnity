using System.IO;
using PhlegmaticOne.FileExplorer.Core.Actions.ViewModels;
using PhlegmaticOne.FileExplorer.Core.FileEntries.ViewModels;
using PhlegmaticOne.FileExplorer.Core.Navigation.ViewModels;
using PhlegmaticOne.FileExplorer.Features.Actions;
using PhlegmaticOne.FileExplorer.Features.Actions.Directories;
using PhlegmaticOne.FileExplorer.Features.Actions.Files;
using PhlegmaticOne.FileExplorer.Features.ExplorerIcons.Services;
using PhlegmaticOne.FileExplorer.Infrastructure.Positioning;
using UnityEngine;

namespace PhlegmaticOne.FileExplorer.Features.Navigation
{
    internal sealed class FileEntryFactory : IFileEntryFactory
    {
        private readonly IExplorerIconsProvider _iconsProvider;
        private readonly FileEntryActionsViewModel _actionsViewModel;
        private readonly Camera _camera;

        private readonly IFileEntryActionsFactory _fileActionsFactory;
        private readonly IFileEntryActionsFactory _directoryActionsFactory;
        
        private NavigationViewModel _navigationViewModel;

        public FileEntryFactory(
            IExplorerIconsProvider iconsProvider, 
            FileEntryActionsViewModel actionsViewModel,
            Camera camera)
        {
            _iconsProvider = iconsProvider;
            _actionsViewModel = actionsViewModel;
            _camera = camera;
            _fileActionsFactory = new FileEntryActionsFactoryFile(_actionsViewModel);
            _directoryActionsFactory = new FileEntryActionsFactoryDirectory(_actionsViewModel);
        }

        public void SetupNavigation(NavigationViewModel navigationViewModel)
        {
            _navigationViewModel = navigationViewModel;
        }
        
        public FileEntryViewModel CreateEntry(FileSystemInfo fileEntry)
        {
            return File.Exists(fileEntry.FullName) 
                ? CreateFileEntry(fileEntry) 
                : CreateDirectoryEntry(fileEntry);
        }

        private FileEntryViewModel CreateFileEntry(FileSystemInfo fileInfo)
        {
            var actionsProvider = new FileEntryActionsProvider(_actionsViewModel, _fileActionsFactory);
            var position = new FileEntryPosition(_camera);
            
            return new FileViewModel(
                fileInfo.FullName, fileInfo.Name, fileInfo.Extension, position,
                _iconsProvider, actionsProvider);
        }

        private FileEntryViewModel CreateDirectoryEntry(FileSystemInfo fileInfo)
        {
            var actionsProvider = new FileEntryActionsProvider(_actionsViewModel, _directoryActionsFactory);
            var position = new FileEntryPosition(_camera);
            
            return new DirectoryViewModel(
                fileInfo.FullName, fileInfo.Name, position,
                _iconsProvider, actionsProvider, _navigationViewModel);
        }
    }
}