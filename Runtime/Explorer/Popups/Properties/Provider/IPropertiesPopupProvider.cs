using System.Threading.Tasks;
using PhlegmaticOne.FileExplorer.Features.FileEntries.ViewModels;

namespace PhlegmaticOne.FileExplorer.Popups.Properties
{
    internal interface IPropertiesPopupProvider
    {
        Task ViewFileProperties(FileEntryViewModel viewModel);
    }
}