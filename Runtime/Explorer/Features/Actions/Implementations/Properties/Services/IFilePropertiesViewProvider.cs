using System.Threading.Tasks;
using PhlegmaticOne.FileExplorer.Features.FileEntries.ViewModels;

namespace PhlegmaticOne.FileExplorer.Features.Actions.Implementations.Properties.Services
{
    internal interface IFilePropertiesViewProvider
    {
        Task ViewFileProperties(FileEntryViewModel viewModel);
    }
}