using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using System.Threading;
using PhlegmaticOne.FileExplorer.Core.FileEntries.ViewModels;
using PhlegmaticOne.FileExplorer.Core.Navigation.ViewModels;

namespace PhlegmaticOne.FileExplorer.Features.Navigation
{
    internal sealed class ExplorerNavigator : IExplorerNavigator
    {
        private readonly IFileEntryFactory _fileEntryFactory;

        public ExplorerNavigator(IFileEntryFactory fileEntryFactory)
        {
            _fileEntryFactory = fileEntryFactory;
        }
        
        public async IAsyncEnumerable<FileEntryViewModel> Navigate(
            NavigationViewModel navigationViewModel, [EnumeratorCancellation] CancellationToken cancellationToken)
        {
            var directory = new DirectoryInfo(navigationViewModel.Path);

            foreach (var fileEntry in directory.EnumerateFileSystemInfos())
            {
                var viewModel = _fileEntryFactory.CreateEntry(fileEntry, navigationViewModel);
                await viewModel.InitializeAsync(cancellationToken);
                yield return viewModel;
            }
        }
    }
}