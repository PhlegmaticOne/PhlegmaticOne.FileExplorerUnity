using PhlegmaticOne.FileExplorer.ExplorerCore.Listeners;
using PhlegmaticOne.FileExplorer.ExplorerCore.Services.StaticView;
using PhlegmaticOne.FileExplorer.ExplorerCore.Services.Views;
using PhlegmaticOne.FileExplorer.Features.Navigation.ViewModels;

namespace PhlegmaticOne.FileExplorer.ExplorerCore.States.Commands
{
    internal sealed class ExplorerShowCommand : IExplorerShowCommand
    {
        private readonly IExplorerViewsProvider _viewsProvider;
        private readonly NavigationViewModel _navigationViewModel;
        private readonly ExplorerActionListeners _listeners;
        private readonly IExplorerStaticView _staticView;

        public ExplorerShowCommand(
            IExplorerViewsProvider viewsProvider,
            NavigationViewModel navigationViewModel,
            ExplorerActionListeners listeners,
            IExplorerStaticView staticView)
        {
            _viewsProvider = viewsProvider;
            _navigationViewModel = navigationViewModel;
            _listeners = listeners;
            _staticView = staticView;
        }
        
        public void Show()
        {
            _staticView.Setup();
            _viewsProvider.Bind();
            _listeners.StartListen();
            _navigationViewModel.NavigateRoot();
        }
    }
}