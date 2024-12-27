using PhlegmaticOne.FileExplorer.Features.Path.Services;
using PhlegmaticOne.FileExplorer.Features.Path.Services.Root;
using PhlegmaticOne.FileExplorer.Features.Path.ViewModels;
using PhlegmaticOne.FileExplorer.Features.Path.Views;
using PhlegmaticOne.FileExplorer.Infrastructure.DependencyInjection;
using PhlegmaticOne.FileExplorer.Infrastructure.DependencyInjection.Installers;
using UnityEngine;

namespace PhlegmaticOne.FileExplorer.Features.Path
{
    internal sealed class PathInstaller : MonoInstaller
    {
        [SerializeField] private PathView _pathView;
        [SerializeField] private PathPartViewCollection _viewCollection;
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