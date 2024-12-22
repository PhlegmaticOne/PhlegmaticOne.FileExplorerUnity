using PhlegmaticOne.FileExplorer.Configuration;
using PhlegmaticOne.FileExplorer.Features.Cancellation;
using PhlegmaticOne.FileExplorer.Features.Views;
using PhlegmaticOne.FileExplorer.Infrastructure.DependencyInjection;
using PhlegmaticOne.FileExplorer.Infrastructure.DependencyInjection.Installers;
using PhlegmaticOne.FileExplorer.Infrastructure.Popups;
using PhlegmaticOne.FileExplorer.States;
using PhlegmaticOne.FileExplorer.States.Commands;
using UnityEngine;

namespace PhlegmaticOne.FileExplorer
{
    internal sealed class ExplorerInstaller : MonoInstaller
    {
        [SerializeField] private FileExplorerConfig _fileExplorerConfig;
        [SerializeField] private PopupProvider _popupProvider;
        [SerializeField] private GameObject _rootObject;
        
        public override void Install(IDependencyContainer container)
        {
            container.RegisterInstance(_popupProvider);
            container.RegisterInstance(_fileExplorerConfig);
            
            container.Register<IExplorerCancellationProvider, ExplorerCancellationProvider>();
            container.Register<IExplorerViewsProvider, ExplorerViewsProvider>();
            
            container.Register<IExplorerCloseCommand, ExplorerCloseCommand>();
            container.Register<IExplorerShowCommand, ExplorerShowCommand>();
            container.Register<IExplorerViewModelDisposer, ExplorerViewModelDisposer>();
            container.Register<IExplorerStateProvider, ExplorerStateProvider>();
            container.RegisterInstance(new ExplorerRootObjectProvider(_rootObject));
        }
    }
}