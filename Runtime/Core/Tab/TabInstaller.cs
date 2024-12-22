using PhlegmaticOne.FileExplorer.Core.Tab.ViewModels;
using PhlegmaticOne.FileExplorer.Core.Tab.Views;
using PhlegmaticOne.FileExplorer.Infrastructure.DependencyInjection;
using PhlegmaticOne.FileExplorer.Infrastructure.DependencyInjection.Installers;
using UnityEngine;

namespace PhlegmaticOne.FileExplorer.Core.Tab
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