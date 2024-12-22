using PhlegmaticOne.FileExplorer.Core.ScreenMessages.Services;
using PhlegmaticOne.FileExplorer.Core.ScreenMessages.ViewModels;
using PhlegmaticOne.FileExplorer.Core.ScreenMessages.Views;
using PhlegmaticOne.FileExplorer.Infrastructure.DependencyInjection;
using PhlegmaticOne.FileExplorer.Infrastructure.DependencyInjection.Installers;
using UnityEngine;

namespace PhlegmaticOne.FileExplorer.Core.ScreenMessages
{
    internal sealed class ScreenMessagesInstaller : MonoInstaller
    {
        [SerializeField] private ScreenMessagesView _screenMessagesView;
        
        public override void Install(IDependencyContainer container)
        {
            container.RegisterInstance(_screenMessagesView);
            container.Register<IScreenMessageTextChangeListener, ScreenMessageTextChangeListener>();
            container.RegisterSelf<ScreenMessagesViewModel>();
        }
    }
}