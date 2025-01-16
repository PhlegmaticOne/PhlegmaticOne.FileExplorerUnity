using PhlegmaticOne.FileExplorer.ExplorerCore.States;
using PhlegmaticOne.FileExplorer.Infrastructure.DependencyInjection;
using PhlegmaticOne.FileExplorer.Infrastructure.DependencyInjection.Installers;
using PhlegmaticOne.FileExplorer.Listeners;
using PhlegmaticOne.FileExplorer.Listeners.Navigation;
using PhlegmaticOne.FileExplorer.Listeners.TabItems;
using PhlegmaticOne.FileExplorer.Listeners.TabText;
using PhlegmaticOne.FileExplorer.Services.Cancellation;
using PhlegmaticOne.FileExplorer.Services.Destroying;
using PhlegmaticOne.FileExplorer.Services.Disposing;
using PhlegmaticOne.FileExplorer.Services.StaticView;
using PhlegmaticOne.FileExplorer.Services.Views;
using PhlegmaticOne.FileExplorer.States;
using PhlegmaticOne.FileExplorer.States.Commands;
using UnityEngine;

namespace PhlegmaticOne.FileExplorer
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
            
            container.Register<IExplorerStates, ExplorerStates>();
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