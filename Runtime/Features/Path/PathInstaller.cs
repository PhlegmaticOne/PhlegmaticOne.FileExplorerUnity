using PhlegmaticOne.FileExplorer.Features.Path.Services;
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
        
        public override void Install(IDependencyContainer container)
        {
            container.RegisterInstance(_pathView);
            container.Register<IPathPartFactory, PathPartFactory>();
            container.Register<IPathParser, PathParser>();
            container.Register<IPathBuilder, PathBuilder>();
            container.RegisterSelf<PathViewModel>();
        }
    }
}