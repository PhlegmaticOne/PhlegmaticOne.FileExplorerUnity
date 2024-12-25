using PhlegmaticOne.FileExplorer.Configuration;
using PhlegmaticOne.FileExplorer.ExplorerCore.Services.Cancellation;
using PhlegmaticOne.FileExplorer.ExplorerCore.Services.Destroying;
using PhlegmaticOne.FileExplorer.ExplorerCore.Services.Disposing;
using PhlegmaticOne.FileExplorer.ExplorerCore.Services.StaticView;
using PhlegmaticOne.FileExplorer.ExplorerCore.Services.Views;
using PhlegmaticOne.FileExplorer.ExplorerCore.States;
using PhlegmaticOne.FileExplorer.ExplorerCore.States.Commands;
using PhlegmaticOne.FileExplorer.Infrastructure.DependencyInjection;
using PhlegmaticOne.FileExplorer.Infrastructure.DependencyInjection.Installers;
using PhlegmaticOne.FileExplorer.Infrastructure.Popups;
using PhlegmaticOne.FileExplorer.Infrastructure.Views;
using TMPro;
using UnityEngine;

namespace PhlegmaticOne.FileExplorer.ExplorerCore
{
    internal sealed class ExplorerInstaller : MonoInstaller
    {
        private class ViewProviderSettings : IViewProviderSettings
        {
            private readonly ExplorerConfig _explorerConfig;

            public ViewProviderSettings(ExplorerConfig explorerConfig)
            {
                _explorerConfig = explorerConfig;
            }

            public TMP_FontAsset FontAsset => _explorerConfig.View.FontAsset;
        }
        
        [SerializeField] private PopupProvider _popupProvider;
        [SerializeField] private GameObject _rootObject;
        [SerializeField] private Canvas _canvas;
        
        public override void Install(IDependencyContainer container)
        {
            container.RegisterInstance(_popupProvider);
            container.RegisterInstance(_canvas);
            
            container.Register<IExplorerCancellationProvider, ExplorerCancellationProvider>();
            container.Register<IExplorerViewsProvider, ExplorerViewsProvider>();
            container.Register<IExplorerStaticView, ExplorerStaticView>();
            
            container.Register<IExplorerCloseCommand, ExplorerCloseCommand>();
            container.Register<IExplorerShowCommand, ExplorerShowCommand>();
            container.Register<IExplorerViewModelDisposer, ExplorerViewModelDisposer>();
            container.Register<IExplorerStateProvider, ExplorerStateProvider>();
            container.RegisterInstance(new ExplorerDestroyer(_rootObject));
            
            container.Register<IViewProvider, ViewProvider>();
            container.Register<IViewProviderSettings, ViewProviderSettings>();
        }
    }
}