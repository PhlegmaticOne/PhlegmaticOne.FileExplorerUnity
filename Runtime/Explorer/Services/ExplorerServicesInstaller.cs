using PhlegmaticOne.FileExplorer.Infrastructure.DependencyInjection;
using PhlegmaticOne.FileExplorer.Infrastructure.DependencyInjection.Installers;
using PhlegmaticOne.FileExplorer.Services.Cancellation;
using PhlegmaticOne.FileExplorer.Services.Destroying;
using PhlegmaticOne.FileExplorer.Services.Disposing;
using PhlegmaticOne.FileExplorer.Services.Internet;
using PhlegmaticOne.FileExplorer.Services.Listeners;
using PhlegmaticOne.FileExplorer.Services.StaticView;
using PhlegmaticOne.FileExplorer.Services.Views;
using UnityEngine;

namespace PhlegmaticOne.FileExplorer.Services
{
    internal sealed class ExplorerServicesInstaller : MonoInstaller
    {
        [SerializeField] private ExplorerSceneObjects _sceneObjects;
        
        public override void Install(IDependencyContainer container)
        {
            container.RegisterInstance(Camera.main);
            container.RegisterInstance(_sceneObjects);
            container.Register<IExplorerCancellationProvider, ExplorerCancellationProvider>();
            container.Register<IExplorerViewsProvider, ExplorerViewsProvider>();
            container.Register<IExplorerViewModelDisposer, ExplorerViewModelDisposer>();
            container.Register<IExplorerViewSetup, ExplorerViewSetup>();
            container.Register<IInternetProvider, InternetProvider>();
            container.Register<IExplorerDestroyer, ExplorerDestroyer>();
            container.RegisterSelf<ExplorerActionListeners>();
        }
    }
}