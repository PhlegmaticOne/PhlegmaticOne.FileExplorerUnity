using System.IO;
using PhlegmaticOne.FileExplorer.Core.FileEntries.ViewModels;
using PhlegmaticOne.FileExplorer.Core.FileEntries.ViewModels.Directories;
using PhlegmaticOne.FileExplorer.Core.Navigation.ViewModels;
using PhlegmaticOne.FileExplorer.Features.Actions;
using PhlegmaticOne.FileExplorer.Features.ExplorerIcons.Services;
using PhlegmaticOne.FileExplorer.Features.FileOperations;

namespace PhlegmaticOne.FileExplorer.Features.Navigation
{
    internal sealed class FileEntryFactory : IFileEntryFactory
    {
        private readonly IExplorerIconsProvider _iconsProvider;
        private readonly FileEntryActionsProvider _fileActionsProvider;
        private readonly FileEntryActionsProvider _directoryActionsProvider;
        private readonly IFileOperations _fileOperations;

        private NavigationViewModel _navigationViewModel;

        public FileEntryFactory(
            IExplorerIconsProvider iconsProvider,
            FileEntryActionsProvider fileActionsProvider,
            FileEntryActionsProvider directoryActionsProvider,
            IFileOperations fileOperations)
        {
            _iconsProvider = iconsProvider;
            _fileActionsProvider = fileActionsProvider;
            _directoryActionsProvider = directoryActionsProvider;
            _fileOperations = fileOperations;
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
            return new Core.FileEntries.ViewModels.Files.FileViewModel(
                fileInfo.FullName, fileInfo.Name, fileInfo.Extension,
                _iconsProvider, _fileActionsProvider, _fileOperations);
        }

        private FileEntryViewModel CreateDirectoryEntry(FileSystemInfo fileInfo)
        {
            return new DirectoryViewModel(
                fileInfo.FullName, fileInfo.Name,
                _iconsProvider, _directoryActionsProvider, _navigationViewModel, _fileOperations);
        }
    }
}