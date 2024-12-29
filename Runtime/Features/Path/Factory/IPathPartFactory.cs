using PhlegmaticOne.FileExplorer.Features.Path.ViewModels;

namespace PhlegmaticOne.FileExplorer.Features.Path.Factory
{
    internal interface IPathPartFactory
    {
        PathPartViewModel CreatePathPart(string pathPart);
    }
}