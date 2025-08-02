using System.IO;
using PhlegmaticOne.FileExplorer.Features.FileEntries.Entities;
using PhlegmaticOne.FileExplorer.Features.FileEntries.Entities.Direcrories;
using PhlegmaticOne.FileExplorer.Features.FileEntries.Entities.Files;
using PhlegmaticOne.FileExplorer.Infrastructure.DependencyInjection;
using PhlegmaticOne.FileExplorer.Services.ShowConfiguration;

namespace PhlegmaticOne.FileExplorer.Features.FileEntries.Factory
{
    internal sealed class FileEntryFactory : IFileEntryFactory
    {
        private readonly IDependencyContainer _container;
        private readonly IExplorerShowConfiguration _showConfiguration;

        public FileEntryFactory(
            IDependencyContainer container, 
            IExplorerShowConfiguration showConfiguration)
        {
            _container = container;
            _showConfiguration = showConfiguration;
        }
        
        public FileEntryViewModel CreateEntry(FileSystemInfo fileEntry)
        {
            return File.Exists(fileEntry.FullName) ? CreateFileEntry(fileEntry) : CreateDirectoryEntry(fileEntry);
        }

        private FileEntryViewModel CreateFileEntry(FileSystemInfo fileInfo)
        {
            var fileEntry = _container.Instantiate<FileViewModel>(
                fileInfo.Name, fileInfo.FullName, fileInfo.Extension);

            var isClickable = _showConfiguration.IsSupportedExtension(fileInfo.Extension);
            fileEntry.IsClickable.SetValueWithoutNotify(isClickable);

            return fileEntry;
        }

        private FileEntryViewModel CreateDirectoryEntry(FileSystemInfo fileInfo)
        {
            return _container.Instantiate<DirectoryViewModel>(fileInfo.Name, fileInfo.FullName);
        }
    }
}