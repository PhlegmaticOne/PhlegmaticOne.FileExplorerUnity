using PhlegmaticOne.FileExplorer.Core.Path.ViewModels;
using PhlegmaticOne.FileExplorer.Infrastructure.DependencyInjection;

namespace PhlegmaticOne.FileExplorer.Core.Path.Services
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