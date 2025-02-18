using System.Threading;
using System.Threading.Tasks;
using PhlegmaticOne.FileExplorer.Features.FileEntries.Actions.Core;
using PhlegmaticOne.FileExplorer.Popups.FileView;

namespace PhlegmaticOne.FileExplorer.Features.FileEntries.Entities.Files.Actions
{
    internal sealed class FileEntryActionShowImage : IFileEntryAction
    {
        private readonly IFileViewImageProvider _viewImageProvider;

        public FileEntryActionShowImage(IFileViewImageProvider viewImageProvider)
        {
            _viewImageProvider = viewImageProvider;
        }

        public Task Execute(FileEntryViewModel fileEntry, CancellationToken token)
        {
            return _viewImageProvider.ViewImageAsync(fileEntry, token);
        }
    }
}