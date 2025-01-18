using PhlegmaticOne.FileExplorer.Infrastructure.DependencyInjection;
using PhlegmaticOne.FileExplorer.Infrastructure.DependencyInjection.Installers;
using PhlegmaticOne.FileExplorer.Services.Cancellation;
using PhlegmaticOne.FileExplorer.Services.Destroying;
using PhlegmaticOne.FileExplorer.Services.Disposing;
using PhlegmaticOne.FileExplorer.Services.StaticView;
using PhlegmaticOne.FileExplorer.Services.Views;
using UnityEngine;

namespace PhlegmaticOne.FileExplorer.Services
{
    internal sealed class ExplorerServicesInstaller : MonoInstaller
    {
        [SerializeField] private GameObject _rootObject;
        [SerializeField] private ExplorerStaticView _staticView;
        
        public override void Install(IDependencyContainer container)
        {
            container.RegisterInstance(Camera.main);
            container.Register<IExplorerCancellationProvider, ExplorerCancellationProvider>();
            container.Register<IExplorerViewsProvider, ExplorerViewsProvider>();
            container.Register<IExplorerViewModelDisposer, ExplorerViewModelDisposer>();
            container.RegisterInstance(_staticView);
            container.RegisterInstance(new ExplorerDestroyer(_rootObject));
        }
    }
}