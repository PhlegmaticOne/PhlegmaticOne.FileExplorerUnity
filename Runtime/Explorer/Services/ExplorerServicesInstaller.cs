using PhlegmaticOne.FileExplorer.Infrastructure.DependencyInjection;
using PhlegmaticOne.FileExplorer.Infrastructure.DependencyInjection.Installers;
using PhlegmaticOne.FileExplorer.Services.ActionListeners;
using PhlegmaticOne.FileExplorer.Services.Cancellation;
using PhlegmaticOne.FileExplorer.Services.ContentLoading;
using PhlegmaticOne.FileExplorer.Services.Destroying;
using PhlegmaticOne.FileExplorer.Services.Internet;
using PhlegmaticOne.FileExplorer.Services.Scene;
using PhlegmaticOne.FileExplorer.Services.StaticViews;
using PhlegmaticOne.FileExplorer.Services.StaticViews.SceneSetup;
using PhlegmaticOne.FileExplorer.Services.ViewModelDisposing;
using UnityEngine;
using UnityEngine.UI;

namespace PhlegmaticOne.FileExplorer.Services
{
    internal sealed class ExplorerServicesInstaller : MonoInstaller
    {
        [SerializeField] private ExplorerSceneObjects _sceneObjects;
        [SerializeField] private ScrollRect _scrollRect;
        [SerializeField] private RectTransform _headerTransform;
        [SerializeField] private VerticalLayoutGroup _safeZoneLayout;
        
        public override void Install(IDependencyContainer container)
        {
            container.RegisterInstance(Camera.main);
            container.RegisterInstance(_sceneObjects);
            container.RegisterInstance(new SceneService(_scrollRect, _headerTransform, _safeZoneLayout));

            container.Register<IExplorerCancellationProvider, ExplorerCancellationProvider>();
            container.Register<IExplorerStaticViewComponentsProvider, ExplorerStaticViewComponentsProvider>();
            container.Register<IExplorerViewModelDisposer, ExplorerViewModelDisposer>();
            container.Register<IExplorerSceneViewSetup, ExplorerSceneViewSetup>();
            container.Register<IInternetProvider, InternetProvider>();
            container.Register<IExplorerDestroyer, ExplorerDestroyer>();
            container.Register<IExplorerActionListeners, ExplorerActionListeners>();
            
            BindContentLoaders(container);
        }

        private void BindContentLoaders(IDependencyContainer container)
        {
            container.Register<IFileAudioLoader, FileAudioLoader>();
            container.Register<IFileTextLoader, FileTextLoader>();
            container.Register<IFileImageLoader, FileImageLoader>();
        }
    }
}