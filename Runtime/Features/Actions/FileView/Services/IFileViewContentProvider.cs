using System.Threading.Tasks;
using PhlegmaticOne.FileExplorer.Core.FileEntries.ViewModels.Files;
using PhlegmaticOne.FileExplorer.Features.Actions.FileView.Core;

namespace PhlegmaticOne.FileExplorer.Features.Actions.FileView.Services
{
    internal interface IFileViewContentProvider
    {
        Task ViewFileAsync(FileViewModel viewModel, FileViewType viewType);
    }
}