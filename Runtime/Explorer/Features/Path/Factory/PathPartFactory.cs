using PhlegmaticOne.FileExplorer.Features.Path.ViewModels;
using PhlegmaticOne.FileExplorer.Infrastructure.DependencyInjection;

namespace PhlegmaticOne.FileExplorer.Features.Path.Factory
{
    internal sealed class PathPartFactory : IPathPartFactory
    {
        private readonly IDependencyContainer _container;

        public PathPartFactory(IDependencyContainer container)
        {
            _container = container;
        }
        
        public PathPartViewModel CreatePathPart(string pathPart)
        {
            return _container.Instantiate<PathPartViewModel>(pathPart);
        }
    }
}