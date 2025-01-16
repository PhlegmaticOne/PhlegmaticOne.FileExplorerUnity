using PhlegmaticOne.FileExplorer.Features.ScreenMessages.ViewModels;
using PhlegmaticOne.FileExplorer.Features.ScreenMessages.Views;
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
            
            container.RegisterSelf<ScreenMessagesViewModel>();
        }
    }
}