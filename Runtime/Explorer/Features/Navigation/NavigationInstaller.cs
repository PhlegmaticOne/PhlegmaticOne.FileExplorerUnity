using PhlegmaticOne.FileExplorer.Features.Navigation.Entities;
using PhlegmaticOne.FileExplorer.Features.Navigation.Listeners;
using PhlegmaticOne.FileExplorer.Features.Navigation.Services.Navigator;
using PhlegmaticOne.FileExplorer.Features.Navigation.Services.Progress;
using PhlegmaticOne.FileExplorer.Infrastructure.DependencyInjection;
using PhlegmaticOne.FileExplorer.Infrastructure.DependencyInjection.Installers;
using UnityEngine;

namespace PhlegmaticOne.FileExplorer.Features.Navigation
{
    internal sealed class NavigationInstaller : MonoInstaller
    {
        [SerializeField] private NavigationView _navigationView;
        
        public override void Install(IDependencyContainer container)
        {
            container.RegisterInstance(_navigationView);
            
            container.Register<IExplorerNavigator, ExplorerNavigator>();
            container.Register<INavigationProgressSetter, NavigationProgressSetter>();
            
            container.RegisterInterfaces<NavigationBackRequestListener>();
            
            container.RegisterSelf<NavigationViewModel>();
        }
    }
}