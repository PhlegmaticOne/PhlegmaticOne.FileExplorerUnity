using PhlegmaticOne.FileExplorer.Features;
using PhlegmaticOne.FileExplorer.Infrastructure;
using PhlegmaticOne.FileExplorer.Infrastructure.DependencyInjection;
using PhlegmaticOne.FileExplorer.Infrastructure.DependencyInjection.Installers;
using PhlegmaticOne.FileExplorer.Popups;
using PhlegmaticOne.FileExplorer.Runtime.Explorer.States;
using PhlegmaticOne.FileExplorer.Services;
using UnityEngine;

namespace PhlegmaticOne.FileExplorer
{
    internal sealed class ExplorerInstaller : MonoInstaller
    {
        [SerializeField] private ExplorerFeaturesInstaller _featuresInstaller;
        [SerializeField] private ExplorerServicesInstaller _servicesInstaller;
        [SerializeField] private ExplorerLifecycleInstaller _lifecycleInstaller;
        [SerializeField] private PopupProviderInstaller _popupProviderInstaller;
        
        public override void Install(IDependencyContainer container)
        {
            _featuresInstaller.Install(container);
            _servicesInstaller.Install(container);
            _popupProviderInstaller.Install(container);
            _lifecycleInstaller.Install(container);
            
            container.InstallFrom<ViewProviderInstaller>();
        }
    }
}