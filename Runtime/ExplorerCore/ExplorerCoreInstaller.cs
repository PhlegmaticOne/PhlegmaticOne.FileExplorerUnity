using PhlegmaticOne.FileExplorer.ExplorerCore.Listeners;
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
        [SerializeField] private ExplorerStaticView _staticView;
        
        public override void Install(IDependencyContainer container)
        {
            BindEntryPoint(container);
            BindCamera(container);
            BindServices(container);
            BindStates(container);
            BindListeners(container);
        }

        private static void BindEntryPoint(IDependencyContainer container)
        {
            container.RegisterSelf<ExplorerEntryPoint>();
        }

        private static void BindCamera(IDependencyContainer container)
        {
            container.RegisterInstance(Camera.main);
        }

        private void BindServices(IDependencyContainer container)
        {
            container.Register<IExplorerCancellationProvider, ExplorerCancellationProvider>();
            container.Register<IExplorerViewsProvider, ExplorerViewsProvider>();
            container.Register<IExplorerViewModelDisposer, ExplorerViewModelDisposer>();
            container.RegisterInstance(_staticView);
            container.RegisterInstance(new ExplorerDestroyer(_rootObject));
        }

        private static void BindStates(IDependencyContainer container)
        {
            container.Register<IExplorerCloseCommand, ExplorerCloseCommand>();
            container.Register<IExplorerShowCommand, ExplorerShowCommand>();
            
            container.Register<IExplorerStateProvider, ExplorerStateProvider>();
        }

        private static void BindListeners(IDependencyContainer container)
        {
            container.RegisterInterfaces<NavigationBackRequestListener>();
            container.RegisterInterfaces<TabCenterTextChangeListener>();
            container.RegisterInterfaces<TabEntriesAddedListener>();
            
            container.RegisterSelf<ExplorerActionListeners>();
        }
    }
}