using PhlegmaticOne.FileExplorer.Features;
using PhlegmaticOne.FileExplorer.Infrastructure;
using PhlegmaticOne.FileExplorer.Infrastructure.DependencyInjection;
using PhlegmaticOne.FileExplorer.Infrastructure.DependencyInjection.Installers;
using PhlegmaticOne.FileExplorer.Listeners;
using PhlegmaticOne.FileExplorer.Runtime.Explorer.States;
using PhlegmaticOne.FileExplorer.Services;
using UnityEngine;

namespace PhlegmaticOne.FileExplorer
{
    internal sealed class ExplorerInstaller : MonoInstaller
    {
        [SerializeField] private ExplorerFeaturesInstaller _featuresInstaller;
        [SerializeField] private ExplorerServicesInstaller _servicesInstaller;
        [SerializeField] private PopupProviderInstaller _popupProviderInstaller;
        
        public override void Install(IDependencyContainer container)
        {
            container.RegisterSelf<ExplorerEntryPoint>();
            
            _featuresInstaller.Install(container);
            _servicesInstaller.Install(container);
            _popupProviderInstaller.Install(container);
            
            container.InstallFrom<ViewProviderInstaller>();
            container.InstallFrom<ExplorerStatesInstaller>();
            container.InstallFrom<ExplorerListenersInstaller>();
        }
    }
}