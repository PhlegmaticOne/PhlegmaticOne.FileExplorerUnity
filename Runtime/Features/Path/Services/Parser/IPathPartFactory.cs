using PhlegmaticOne.FileExplorer.Features.Path.ViewModels;

namespace PhlegmaticOne.FileExplorer.Features.Path.Services
{
    internal interface IPathPartFactory
    {
        PathPartViewModel CreatePathPart(string pathPart);
    }
}