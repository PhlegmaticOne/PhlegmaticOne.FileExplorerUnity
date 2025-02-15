using PhlegmaticOne.FileExplorer.Features.Progress.Entities;
using PhlegmaticOne.FileExplorer.Infrastructure.DependencyInjection;
using PhlegmaticOne.FileExplorer.Infrastructure.DependencyInjection.Installers;
using UnityEngine;

namespace PhlegmaticOne.FileExplorer.Features.Progress
{
    internal sealed class ProgressInstaller : MonoInstaller
    {
        [SerializeField] private ProgressView _progressView;
        
        public override void Install(IDependencyContainer container)
        {
            container.RegisterInstance(_progressView);
            
            container.RegisterSelf<ProgressViewModel>();
        }
    }
}