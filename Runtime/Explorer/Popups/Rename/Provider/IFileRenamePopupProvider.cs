using System.Threading.Tasks;
using PhlegmaticOne.FileExplorer.Features.FileEntries.ViewModels;

namespace PhlegmaticOne.FileExplorer.Popups.Rename
{
    internal interface IFileRenamePopupProvider
    {
        Task<FileRenameResult> GetRenameData(FileEntryViewModel viewModel);
    }
}