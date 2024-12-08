using System.Collections.Generic;
using System.IO;
using PhlegmaticOne.FileExplorer.Core.FileEntries.ViewModels;

namespace PhlegmaticOne.FileExplorer.Features.Navigation
{
    internal sealed class ExplorerNavigator : IExplorerNavigator
    {
        private readonly IFileEntryFactory _fileEntryFactory;

        public ExplorerNavigator(IFileEntryFactory fileEntryFactory)
        {
            _fileEntryFactory = fileEntryFactory;
        }
        
        public async IAsyncEnumerable<FileEntryViewModel> Navigate(string path)
        {
            var directory = new DirectoryInfo(path);

            foreach (var fileEntry in directory.EnumerateFileSystemInfos())
            {
                var viewModel = _fileEntryFactory.CreateEntry(fileEntry);
                await viewModel.InitializeAsync();
                yield return viewModel;
            }
        }
    }
}