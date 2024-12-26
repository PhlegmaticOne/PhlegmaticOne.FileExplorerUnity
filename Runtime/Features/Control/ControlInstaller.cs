using PhlegmaticOne.FileExplorer.Features.Control.ViewModels;
using PhlegmaticOne.FileExplorer.Features.Control.Views;
using PhlegmaticOne.FileExplorer.Infrastructure.DependencyInjection;
using PhlegmaticOne.FileExplorer.Infrastructure.DependencyInjection.Installers;
using UnityEngine;

namespace PhlegmaticOne.FileExplorer.Features.Control
{
    internal sealed class ControlInstaller : MonoInstaller
    {
        [SerializeField] private ControlView _controlView;
        
        public override void Install(IDependencyContainer container)
        {
            container.RegisterInstance(_controlView);
            container.RegisterSelf<ControlViewModel>();
        }
    }
}