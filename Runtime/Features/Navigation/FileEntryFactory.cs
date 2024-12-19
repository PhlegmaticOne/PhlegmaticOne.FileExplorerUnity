using System.IO;
using PhlegmaticOne.FileExplorer.Core.FileEntries.ViewModels;
using PhlegmaticOne.FileExplorer.Core.FileEntries.ViewModels.Directories;
using PhlegmaticOne.FileExplorer.Core.FileEntries.ViewModels.Files;
using PhlegmaticOne.FileExplorer.Infrastructure.DependencyInjection;

namespace PhlegmaticOne.FileExplorer.Features.Navigation
{
    internal sealed class FileEntryFactory : IFileEntryFactory
    {
        private readonly IDependencyContainer _container;

        public FileEntryFactory(IDependencyContainer container)
        {
            _container = container;
        }
        
        public FileEntryViewModel CreateEntry(FileSystemInfo fileEntry)
        {
            return File.Exists(fileEntry.FullName) ? CreateFileEntry(fileEntry) : CreateDirectoryEntry(fileEntry);
        }

        private FileEntryViewModel CreateFileEntry(FileSystemInfo fileInfo)
        {
            return _container.Instantiate<FileViewModel>(fileInfo.Name, fileInfo.FullName, fileInfo.Extension);
        }

        private FileEntryViewModel CreateDirectoryEntry(FileSystemInfo fileInfo)
        {
            return _container.Instantiate<DirectoryViewModel>(fileInfo.Name, fileInfo.FullName);
        }
    }
}