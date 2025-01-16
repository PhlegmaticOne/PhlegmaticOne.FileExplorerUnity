using System.Threading.Tasks;
using PhlegmaticOne.FileExplorer.Features.FileEntries.ViewModels.Files;

namespace PhlegmaticOne.FileExplorer.Features.Actions.Implementations.FileView.Services
{
    internal interface IFileViewContentProvider
    {
        Task ViewFileAsync(FileViewModel viewModel, FileViewType viewType);
    }
}