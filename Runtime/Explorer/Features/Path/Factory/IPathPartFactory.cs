using PhlegmaticOne.FileExplorer.Features.Path.Entities.PathPart;

namespace PhlegmaticOne.FileExplorer.Features.Path.Factory
{
    internal interface IPathPartFactory
    {
        PathPartViewModel CreatePathPart(string pathPart);
    }
}