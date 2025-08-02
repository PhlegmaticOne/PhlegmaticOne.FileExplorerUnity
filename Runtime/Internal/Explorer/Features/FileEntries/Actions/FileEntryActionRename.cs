using System.Threading;
using System.Threading.Tasks;
using PhlegmaticOne.FileExplorer.Features.FileEntries.Actions.Core;
using PhlegmaticOne.FileExplorer.Features.FileEntries.Entities;
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

        public async Task Execute(FileEntryViewModel fileEntry, CancellationToken token)
        {
            var renameData = await _renamePopupProvider.GetRenameData(fileEntry);

            if (renameData.WillRename)
            {
                fileEntry.Rename(renameData.NewName);
            }
        }
    }
}