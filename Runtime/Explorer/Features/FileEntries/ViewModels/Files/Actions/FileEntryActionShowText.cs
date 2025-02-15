using System.Threading;
using System.Threading.Tasks;
using PhlegmaticOne.FileExplorer.Features.FileEntries.Actions;
using PhlegmaticOne.FileExplorer.Popups.FileView;

namespace PhlegmaticOne.FileExplorer.Features.FileEntries.ViewModels.Files.Actions
{
    internal sealed class FileEntryActionShowText : IFileEntryAction
    {
        private readonly IFileViewTextProvider _viewTextProvider;

        public FileEntryActionShowText(IFileViewTextProvider viewTextProvider)
        {
            _viewTextProvider = viewTextProvider;
        }

        public Task ExecuteAction(FileEntryViewModel fileEntry, CancellationToken token)
        {
            return _viewTextProvider.ViewTextAsync(fileEntry, token);
        }
    }
}