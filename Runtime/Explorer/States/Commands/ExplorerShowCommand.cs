using PhlegmaticOne.FileExplorer.Features.Navigation.Entities;
using PhlegmaticOne.FileExplorer.Services.ActionListeners;
using PhlegmaticOne.FileExplorer.Services.StaticViews;
using PhlegmaticOne.FileExplorer.Services.StaticViews.SceneSetup;

namespace PhlegmaticOne.FileExplorer.States.Commands
{
    internal sealed class ExplorerShowCommand : IExplorerShowCommand
    {
        private readonly IExplorerStaticViewComponentsProvider _staticViewComponentsProvider;
        private readonly NavigationViewModel _navigationViewModel;
        private readonly ExplorerActionListeners _listeners;
        private readonly IExplorerSceneViewSetup _viewSetup;

        public ExplorerShowCommand(
            IExplorerStaticViewComponentsProvider staticViewComponentsProvider,
            NavigationViewModel navigationViewModel,
            ExplorerActionListeners listeners,
            IExplorerSceneViewSetup viewSetup)
        {
            _staticViewComponentsProvider = staticViewComponentsProvider;
            _navigationViewModel = navigationViewModel;
            _listeners = listeners;
            _viewSetup = viewSetup;
        }
        
        public void Show()
        {
            _viewSetup.Setup();
            _staticViewComponentsProvider.Bind();
            _listeners.StartListen();
            _navigationViewModel.NavigateRoot();
        }
    }
}