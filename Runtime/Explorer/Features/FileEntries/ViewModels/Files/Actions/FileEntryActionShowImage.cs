using System.Threading;
using System.Threading.Tasks;
using PhlegmaticOne.FileExplorer.Features.FileEntries.Actions;
using PhlegmaticOne.FileExplorer.Popups.FileView;

namespace PhlegmaticOne.FileExplorer.Features.FileEntries.ViewModels.Files.Actions
{
    internal sealed class FileEntryActionShowImage : IFileEntryAction
    {
        private readonly IFileViewImageProvider _viewImageProvider;

        public FileEntryActionShowImage(IFileViewImageProvider viewImageProvider)
        {
            _viewImageProvider = viewImageProvider;
        }

        public Task ExecuteAction(FileEntryViewModel fileEntry, CancellationToken token)
        {
            return _viewImageProvider.ViewImageAsync(fileEntry, token);
        }
    }
}