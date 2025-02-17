using PhlegmaticOne.FileExplorer.Features.HeaderInfo.Entities;
using PhlegmaticOne.FileExplorer.Infrastructure.DependencyInjection;
using PhlegmaticOne.FileExplorer.Infrastructure.DependencyInjection.Installers;
using UnityEngine;

namespace PhlegmaticOne.FileExplorer.Features.HeaderInfo
{
    internal sealed class HeaderInfoInstaller : MonoInstaller
    {
        [SerializeField] private HeaderInfoView _headerInfoView;
        
        public override void Install(IDependencyContainer container)
        {
            container.RegisterInstance(_headerInfoView);
            
            container.RegisterSelf<HeaderInfoViewModel>();
        }
    }
}