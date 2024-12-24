using PhlegmaticOne.FileExplorer.Features.Navigation.Listeners;
using PhlegmaticOne.FileExplorer.Features.Navigation.Services;
using PhlegmaticOne.FileExplorer.Features.Navigation.ViewModels;
using PhlegmaticOne.FileExplorer.Features.Navigation.Views;
using PhlegmaticOne.FileExplorer.Infrastructure.DependencyInjection;
using PhlegmaticOne.FileExplorer.Infrastructure.DependencyInjection.Installers;
using UnityEngine;
using UnityEngine.Serialization;

namespace PhlegmaticOne.FileExplorer.Features.Navigation
{
    internal sealed class NavigationInstaller : MonoInstaller
    {
        [SerializeField] private NavigationView _navigationView;
        [FormerlySerializedAs("_loadingTextListenerConfig")] [SerializeField] private LoadingTextConfig _loadingTextConfig;
        
        public override void Install(IDependencyContainer container)
        {
            container.RegisterInstance(_navigationView);
            container.Register<IExplorerNavigator, ExplorerNavigator>();
            container.RegisterSelf<NavigationViewModel>();
            
            container.RegisterInterfaces<LoadingTextListener>();
            container.RegisterSelf<LoadingTextFormatter>();
            container.RegisterInstance(_loadingTextConfig);
        }
    }
}