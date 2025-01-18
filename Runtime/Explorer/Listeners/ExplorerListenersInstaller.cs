using PhlegmaticOne.FileExplorer.Infrastructure.DependencyInjection;
using PhlegmaticOne.FileExplorer.Infrastructure.DependencyInjection.Installers;
using PhlegmaticOne.FileExplorer.Listeners.Navigation;
using PhlegmaticOne.FileExplorer.Listeners.TabItems;
using PhlegmaticOne.FileExplorer.Listeners.TabText;

namespace PhlegmaticOne.FileExplorer.Listeners
{
    internal sealed class ExplorerListenersInstaller : IInstaller
    {
        public void Install(IDependencyContainer container)
        {
            container.RegisterInterfaces<NavigationBackRequestListener>();
            container.RegisterInterfaces<TabCenterTextChangeListener>();
            container.RegisterInterfaces<TabEntriesAddedListener>();
            
            container.RegisterSelf<ExplorerActionListeners>();
        }
    }
}