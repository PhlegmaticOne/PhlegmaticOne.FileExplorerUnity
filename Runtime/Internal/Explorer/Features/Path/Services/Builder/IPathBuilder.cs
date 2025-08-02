using PhlegmaticOne.FileExplorer.Features.Path.Entities.PathPart;

namespace PhlegmaticOne.FileExplorer.Features.Path.Services.Builder
{
    internal interface IPathBuilder
    {
        string BuildPathUntilPart(PathPartViewModel viewModel);
    }
}