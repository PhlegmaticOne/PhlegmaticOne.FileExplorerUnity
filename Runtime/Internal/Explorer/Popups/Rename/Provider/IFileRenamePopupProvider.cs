using System.Threading.Tasks;
using PhlegmaticOne.FileExplorer.Features.FileEntries.Entities;

namespace PhlegmaticOne.FileExplorer.Popups.Rename
{
    internal interface IFileRenamePopupProvider
    {
        Task<FileRenameResult> GetRenameData(FileEntryViewModel file);
    }
}