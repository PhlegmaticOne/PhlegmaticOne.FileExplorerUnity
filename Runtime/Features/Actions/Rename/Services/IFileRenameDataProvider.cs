using System.Threading.Tasks;
using PhlegmaticOne.FileExplorer.Core.FileEntries.ViewModels;

namespace PhlegmaticOne.FileExplorer.Features.Actions.Rename
{
    internal interface IFileRenameDataProvider
    {
        Task<FileEntryRenameDataResult> GetRenameData(FileEntryViewModel viewModel);
    }
}