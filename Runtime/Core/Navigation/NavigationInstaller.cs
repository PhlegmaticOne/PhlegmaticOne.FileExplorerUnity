using PhlegmaticOne.FileExplorer.Core.Navigation.Services;
using PhlegmaticOne.FileExplorer.Core.Navigation.ViewModels;
using PhlegmaticOne.FileExplorer.Core.Navigation.Views;
using PhlegmaticOne.FileExplorer.Infrastructure.DependencyInjection;
using PhlegmaticOne.FileExplorer.Infrastructure.DependencyInjection.Installers;
using UnityEngine;

namespace PhlegmaticOne.FileExplorer.Core.Navigation
{
    internal sealed class NavigationInstaller : MonoInstaller
    {
        [SerializeField] private NavigationView _navigationView;
        
        public override void Install(IDependencyContainer container)
        {
            container.RegisterInstance(_navigationView);
            container.Register<IExplorerNavigator, ExplorerNavigator>();
            container.RegisterSelf<NavigationViewModel>();
        }
    }
}