using System.Threading.Tasks;
using PhlegmaticOne.FileExplorer.Features.FileEntries.ViewModels;

namespace PhlegmaticOne.FileExplorer.Features.Actions.Implementations.Rename.Services
{
    internal interface IFileRenameDataProvider
    {
        Task<FileEntryRenameDataResult> GetRenameData(FileEntryViewModel viewModel);
    }
}