using PhlegmaticOne.FileExplorer.Core.Path.ViewModels;

namespace PhlegmaticOne.FileExplorer.Core.Path.Services
{
    internal interface IPathBuilder
    {
        string BuildPathUntilPart(PathPartViewModel viewModel);
    }
}