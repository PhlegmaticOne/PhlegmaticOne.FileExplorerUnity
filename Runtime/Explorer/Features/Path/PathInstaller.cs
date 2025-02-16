using PhlegmaticOne.FileExplorer.Features.Path.Entities.Path;
using PhlegmaticOne.FileExplorer.Features.Path.Entities.PathPart;
using PhlegmaticOne.FileExplorer.Features.Path.Factory;
using PhlegmaticOne.FileExplorer.Features.Path.Services.Builder;
using PhlegmaticOne.FileExplorer.Features.Path.Services.Parser;
using PhlegmaticOne.FileExplorer.Features.Path.Services.Root;
using PhlegmaticOne.FileExplorer.Infrastructure.DependencyInjection;
using PhlegmaticOne.FileExplorer.Infrastructure.DependencyInjection.Installers;
using UnityEngine;

namespace PhlegmaticOne.FileExplorer.Features.Path
{
    internal sealed class PathInstaller : MonoInstaller
    {
        [SerializeField] private PathView _pathView;
        [SerializeField] private ComponentCollectionPathParts _viewCollection;
        [SerializeField] private PathPartView _pathPartViewPrefab;
        
        public override void Install(IDependencyContainer container)
        {
            container.RegisterInstance(_pathView);
            container.RegisterInstance(_viewCollection);
            
            container.RegisterPrefab(_pathPartViewPrefab);
            
            container.Register<IPathPartFactory, PathPartFactory>();
            container.Register<IPathParser, PathParser>();
            container.Register<IPathBuilder, PathBuilder>();
            container.Register<IRootPathProvider, RootPathProvider>();
            
            container.RegisterSelf<PathViewModel>();
        }
    }
}