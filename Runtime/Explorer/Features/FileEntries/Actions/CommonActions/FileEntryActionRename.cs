using System.Threading;
using System.Threading.Tasks;
using PhlegmaticOne.FileExplorer.Features.FileEntries.ViewModels;
using PhlegmaticOne.FileExplorer.Popups.Rename;

namespace PhlegmaticOne.FileExplorer.Features.FileEntries.Actions
{
    internal sealed class FileEntryActionRename : IFileEntryAction
    {
        private readonly IFileRenamePopupProvider _renamePopupProvider;

        public FileEntryActionRename(IFileRenamePopupProvider renamePopupProvider)
        {
            _renamePopupProvider = renamePopupProvider;
        }

        public async Task ExecuteAction(FileEntryViewModel fileEntry, CancellationToken token)
        {
            var renameData = await _renamePopupProvider.GetRenameData(fileEntry);

            if (renameData.WillRename)
            {
                fileEntry.Rename(renameData.NewName);
            }
        }
    }
}