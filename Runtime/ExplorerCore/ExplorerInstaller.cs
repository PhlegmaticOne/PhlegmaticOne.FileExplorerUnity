using PhlegmaticOne.FileExplorer.Configuration;
using PhlegmaticOne.FileExplorer.ExplorerCore.Services.Cancellation;
using PhlegmaticOne.FileExplorer.ExplorerCore.Services.Disposing;
using PhlegmaticOne.FileExplorer.ExplorerCore.Services.RootObject;
using PhlegmaticOne.FileExplorer.ExplorerCore.Services.Views;
using PhlegmaticOne.FileExplorer.ExplorerCore.States;
using PhlegmaticOne.FileExplorer.ExplorerCore.States.Commands;
using PhlegmaticOne.FileExplorer.Infrastructure.DependencyInjection;
using PhlegmaticOne.FileExplorer.Infrastructure.DependencyInjection.Installers;
using PhlegmaticOne.FileExplorer.Infrastructure.Popups;
using UnityEngine;

namespace PhlegmaticOne.FileExplorer.ExplorerCore
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