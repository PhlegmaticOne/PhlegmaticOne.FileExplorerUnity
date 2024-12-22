using PhlegmaticOne.FileExplorer.Features.Tab.ViewModels;
using PhlegmaticOne.FileExplorer.Features.Tab.Views;
using PhlegmaticOne.FileExplorer.Infrastructure.DependencyInjection;
using PhlegmaticOne.FileExplorer.Infrastructure.DependencyInjection.Installers;
using UnityEngine;

namespace PhlegmaticOne.FileExplorer.Features.Tab
{
    internal sealed class TabInstaller : MonoInstaller
    {
        [SerializeField] private TabView _tabView;
        
        public override void Install(IDependencyContainer container)
        {
            container.RegisterInstance(_tabView);
            container.RegisterSelf<TabViewModel>();
        }
    }
}