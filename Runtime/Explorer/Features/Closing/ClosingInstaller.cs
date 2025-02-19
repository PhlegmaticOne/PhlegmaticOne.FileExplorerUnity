using PhlegmaticOne.FileExplorer.Features.Closing.Entities;
using PhlegmaticOne.FileExplorer.Infrastructure.DependencyInjection;
using PhlegmaticOne.FileExplorer.Infrastructure.DependencyInjection.Installers;
using UnityEngine;

namespace PhlegmaticOne.FileExplorer.Features.Closing
{
    internal sealed class ClosingInstaller : MonoInstaller
    {
        [SerializeField] private ClosingView _closingView;
        
        public override void Install(IDependencyContainer container)
        {
            container.RegisterInstance(_closingView);
            
            container.RegisterSelf<ClosingViewModel>();
        }
    }
}