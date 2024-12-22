using System.Threading.Tasks;
using PhlegmaticOne.FileExplorer.Core.FileEntries.ViewModels;

namespace PhlegmaticOne.FileExplorer.Features.Actions.Properties.Services
{
    internal interface IFilePropertiesViewProvider
    {
        Task ViewFileProperties(FileEntryViewModel viewModel);
    }
}