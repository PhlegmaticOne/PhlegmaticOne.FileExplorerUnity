using PhlegmaticOne.FileExplorer.Infrastructure.DependencyInjection;
using PhlegmaticOne.FileExplorer.Infrastructure.DependencyInjection.Installers;
using PhlegmaticOne.FileExplorer.Services.ActionListeners;
using PhlegmaticOne.FileExplorer.Services.Cancellation;
using PhlegmaticOne.FileExplorer.Services.Destroying;
using PhlegmaticOne.FileExplorer.Services.Internet;
using PhlegmaticOne.FileExplorer.Services.StaticViews;
using PhlegmaticOne.FileExplorer.Services.StaticViews.SceneSetup;
using PhlegmaticOne.FileExplorer.Services.ViewModelDisposing;
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
            container.Register<IExplorerStaticViewComponentsProvider, ExplorerStaticViewComponentsProvider>();
            container.Register<IExplorerViewModelDisposer, ExplorerViewModelDisposer>();
            container.Register<IExplorerSceneViewSetup, ExplorerSceneViewSetup>();
            container.Register<IInternetProvider, InternetProvider>();
            container.Register<IExplorerDestroyer, ExplorerDestroyer>();
            container.RegisterSelf<ExplorerActionListeners>();
        }
    }
}