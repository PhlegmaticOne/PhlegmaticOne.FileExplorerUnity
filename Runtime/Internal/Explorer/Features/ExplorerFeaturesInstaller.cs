using PhlegmaticOne.FileExplorer.Infrastructure.DependencyInjection;
using PhlegmaticOne.FileExplorer.Infrastructure.DependencyInjection.Installers;
using UnityEngine;

namespace PhlegmaticOne.FileExplorer.Features
{
    internal sealed class ExplorerFeaturesInstaller : MonoInstaller
    {
        [SerializeField] private MonoInstaller[] _featureInstallers;
        
        public override void Install(IDependencyContainer container)
        {
            foreach (var featureInstaller in _featureInstallers)
            {
                featureInstaller.Install(container);
            }
        }
    }
}