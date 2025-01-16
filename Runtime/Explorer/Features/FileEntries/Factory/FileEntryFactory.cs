using System.IO;
using PhlegmaticOne.FileExplorer.Features.FileEntries.ViewModels;
using PhlegmaticOne.FileExplorer.Features.FileEntries.ViewModels.Direcrories;
using PhlegmaticOne.FileExplorer.Features.FileEntries.ViewModels.Files;
using PhlegmaticOne.FileExplorer.Infrastructure.DependencyInjection;

namespace PhlegmaticOne.FileExplorer.Features.FileEntries.Factory
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