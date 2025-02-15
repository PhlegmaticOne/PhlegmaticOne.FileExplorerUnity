using PhlegmaticOne.FileExplorer.Features.ScreenMessages.Entities;
using PhlegmaticOne.FileExplorer.Features.ScreenMessages.Listeners;
using PhlegmaticOne.FileExplorer.Infrastructure.DependencyInjection;
using PhlegmaticOne.FileExplorer.Infrastructure.DependencyInjection.Installers;
using UnityEngine;

namespace PhlegmaticOne.FileExplorer.Features.ScreenMessages
{
    internal sealed class ScreenMessagesInstaller : MonoInstaller
    {
        [SerializeField] private ScreenMessagesView _screenMessagesView;
        
        public override void Install(IDependencyContainer container)
        {
            container.RegisterInstance(_screenMessagesView);
            
            container.RegisterInterfaces<TabCenterTextChangeListener>();
            
            container.RegisterSelf<ScreenMessagesViewModel>();
        }
    }
}