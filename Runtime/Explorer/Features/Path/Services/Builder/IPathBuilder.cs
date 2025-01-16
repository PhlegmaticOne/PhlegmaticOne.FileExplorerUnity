using PhlegmaticOne.FileExplorer.Features.Path.ViewModels;

namespace PhlegmaticOne.FileExplorer.Features.Path.Services
{
    internal interface IPathBuilder
    {
        string BuildPathUntilPart(PathPartViewModel viewModel);
    }
}