using PhlegmaticOne.FileExplorer.ExplorerCore.Listeners.Navigation;
using PhlegmaticOne.FileExplorer.ExplorerCore.Listeners.TabItems;
using PhlegmaticOne.FileExplorer.ExplorerCore.Listeners.TabText;
using PhlegmaticOne.FileExplorer.ExplorerCore.Services.Cancellation;
using PhlegmaticOne.FileExplorer.ExplorerCore.Services.Destroying;
using PhlegmaticOne.FileExplorer.ExplorerCore.Services.Disposing;
using PhlegmaticOne.FileExplorer.ExplorerCore.Services.StaticView;
using PhlegmaticOne.FileExplorer.ExplorerCore.Services.Views;
using PhlegmaticOne.FileExplorer.ExplorerCore.States;
using PhlegmaticOne.FileExplorer.ExplorerCore.States.Commands;
using PhlegmaticOne.FileExplorer.Infrastructure.DependencyInjection;
using PhlegmaticOne.FileExplorer.Infrastructure.DependencyInjection.Installers;
using UnityEngine;

namespace PhlegmaticOne.FileExplorer.ExplorerCore
{
    internal sealed class ExplorerCoreInstaller : MonoInstaller
    {
        [SerializeField] private GameObject _rootObject;
        [SerializeField] private Canvas _canvas;
        
        public override void Install(IDependencyContainer container)
        {
            container.RegisterInstance(_canvas);
            
            container.Register<IExplorerCancellationProvider, ExplorerCancellationProvider>();
            container.Register<IExplorerViewsProvider, ExplorerViewsProvider>();
            container.Register<IExplorerStaticView, ExplorerStaticView>();
            container.RegisterInstance(new ExplorerDestroyer(_rootObject));

            container.Register<IExplorerCloseCommand, ExplorerCloseCommand>();
            container.Register<IExplorerShowCommand, ExplorerShowCommand>();
            container.Register<IExplorerViewModelDisposer, ExplorerViewModelDisposer>();
            container.Register<IExplorerStateProvider, ExplorerStateProvider>();
            
            container.RegisterInterfaces<NavigationBackRequestListener>();
            container.RegisterInterfaces<TabCenterTextChangeListener>();
            container.RegisterInterfaces<TabEntriesAddedListener>();
            
            container.RegisterSelf<ExplorerEntryPoint>();
        }
    }
}