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
        [SerializeField] private LoadingTextView _loadingTextView;
        
        public override void Install(IDependencyContainer container)
        {
            container.RegisterInstance(_navigationView);
            container.RegisterInstance(_loadingTextView);
            container.Register<IExplorerNavigator, ExplorerNavigator>();
            container.RegisterSelf<NavigationViewModel>();
        }
    }
}