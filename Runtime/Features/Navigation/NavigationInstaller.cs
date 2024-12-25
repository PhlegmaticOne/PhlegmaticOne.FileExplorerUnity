using PhlegmaticOne.FileExplorer.Features.Navigation.Services;
using PhlegmaticOne.FileExplorer.Features.Navigation.ViewModels;
using PhlegmaticOne.FileExplorer.Features.Navigation.Views;
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
            container.RegisterSelf<NavigationViewModel>();
        }
    }
}