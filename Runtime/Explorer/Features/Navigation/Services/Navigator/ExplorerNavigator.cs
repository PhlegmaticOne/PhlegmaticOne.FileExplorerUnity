using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using System.Threading;
using PhlegmaticOne.FileExplorer.Features.FileEntries.Entities;
using PhlegmaticOne.FileExplorer.Features.FileEntries.Factory;
using PhlegmaticOne.FileExplorer.Infrastructure.Extensions;
using ZLinq;

namespace PhlegmaticOne.FileExplorer.Features.Navigation.Services.Navigator
{
    internal sealed class ExplorerNavigator : IExplorerNavigator
    {
        private readonly IFileEntryFactory _fileEntryFactory;

        public ExplorerNavigator(IFileEntryFactory fileEntryFactory)
        {
            _fileEntryFactory = fileEntryFactory;
        }
        
        public async IAsyncEnumerable<FileEntryViewModel> Navigate(
            string path, [EnumeratorCancellation] CancellationToken cancellationToken)
        {
            var directory = new DirectoryInfo(path);
            
            foreach (var fileEntry in directory.Children())
            {
                var viewModel = _fileEntryFactory.CreateEntry(fileEntry);
                await viewModel.InitializeAsync(cancellationToken);
                yield return viewModel;
            }
        }
    }
}