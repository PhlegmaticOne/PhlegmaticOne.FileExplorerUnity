using System.Threading.Tasks;
using PhlegmaticOne.FileExplorer.Core.FileEntries.ViewModels;

namespace PhlegmaticOne.FileExplorer.Features.Actions
{
    internal interface IFileEntryAction
    {
        string Description { get; }
        Task Execute(FileEntryViewModel viewModel);
    }
}