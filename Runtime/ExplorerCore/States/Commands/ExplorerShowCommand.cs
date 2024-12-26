using PhlegmaticOne.FileExplorer.ExplorerCore.Listeners.TabText;
using PhlegmaticOne.FileExplorer.ExplorerCore.Services.StaticView;
using PhlegmaticOne.FileExplorer.ExplorerCore.Services.Views;
using PhlegmaticOne.FileExplorer.Features.Navigation.ViewModels;

namespace PhlegmaticOne.FileExplorer.ExplorerCore.States.Commands
{
    internal sealed class ExplorerShowCommand : IExplorerShowCommand
    {
        private readonly IExplorerViewsProvider _viewsProvider;
        private readonly NavigationViewModel _navigationViewModel;
        private readonly ITabCenterTextChangeListener _textChangeListener;
        private readonly IExplorerStaticView _staticView;

        public ExplorerShowCommand(
            IExplorerViewsProvider viewsProvider,
            NavigationViewModel navigationViewModel,
            ITabCenterTextChangeListener textChangeListener,
            IExplorerStaticView staticView)
        {
            _viewsProvider = viewsProvider;
            _navigationViewModel = navigationViewModel;
            _textChangeListener = textChangeListener;
            _staticView = staticView;
        }
        
        public void Show()
        {
            _staticView.Setup();
            _viewsProvider.Bind();
            _textChangeListener.StartListen();
            _navigationViewModel.NavigateRoot();
        }
    }
}