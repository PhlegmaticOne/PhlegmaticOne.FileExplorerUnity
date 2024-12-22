using PhlegmaticOne.FileExplorer.Core.Explorer.Listeners;
using PhlegmaticOne.FileExplorer.Core.Explorer.ViewModels;
using PhlegmaticOne.FileExplorer.Core.Explorer.Views;
using PhlegmaticOne.FileExplorer.Infrastructure.DependencyInjection;
using PhlegmaticOne.FileExplorer.Infrastructure.DependencyInjection.Installers;
using UnityEngine;

namespace PhlegmaticOne.FileExplorer.Core.Control
{
    internal sealed class ControlInstaller : MonoInstaller
    {
        [SerializeField] private ControlView _controlView;
        
        public override void Install(IDependencyContainer container)
        {
            container.RegisterInstance(_controlView);
            container.RegisterInterfaces<BackPressedListener>();
            container.RegisterSelf<ControlViewModel>();
        }
    }
}