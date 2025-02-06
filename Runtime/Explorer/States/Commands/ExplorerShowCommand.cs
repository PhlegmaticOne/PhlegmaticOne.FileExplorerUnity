using PhlegmaticOne.FileExplorer.Features.Navigation.ViewModels;
using PhlegmaticOne.FileExplorer.Services.Listeners;
using PhlegmaticOne.FileExplorer.Services.StaticView;
using PhlegmaticOne.FileExplorer.Services.Views;

namespace PhlegmaticOne.FileExplorer.States.Commands
{
    internal sealed class ExplorerShowCommand : IExplorerShowCommand
    {
        private readonly IExplorerViewsProvider _viewsProvider;
        private readonly NavigationViewModel _navigationViewModel;
        private readonly ExplorerActionListeners _listeners;
        private readonly IExplorerViewSetup _viewSetup;

        public ExplorerShowCommand(
            IExplorerViewsProvider viewsProvider,
            NavigationViewModel navigationViewModel,
            ExplorerActionListeners listeners,
            IExplorerViewSetup viewSetup)
        {
            _viewsProvider = viewsProvider;
            _navigationViewModel = navigationViewModel;
            _listeners = listeners;
            _viewSetup = viewSetup;
        }
        
        public void Show()
        {
            _viewSetup.Setup();
            _viewsProvider.Bind();
            _listeners.StartListen();
            _navigationViewModel.NavigateRoot();
        }
    }
}