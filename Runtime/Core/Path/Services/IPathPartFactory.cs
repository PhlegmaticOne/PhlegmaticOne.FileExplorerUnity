using PhlegmaticOne.FileExplorer.Core.Path.ViewModels;

namespace PhlegmaticOne.FileExplorer.Core.Path.Services
{
    internal interface IPathPartFactory
    {
        PathPartViewModel CreatePathPart(string pathPart);
    }
}