using PhlegmaticOne.FileExplorer.Core.Navigation.ViewModels;
using PhlegmaticOne.FileExplorer.Core.ScreenMessages.Services;
using PhlegmaticOne.FileExplorer.Features.Views;

namespace PhlegmaticOne.FileExplorer.States.Commands
{
    internal sealed class ExplorerShowCommand : IExplorerShowCommand
    {
        private readonly IExplorerViewsProvider _viewsProvider;
        private readonly NavigationViewModel _navigationViewModel;
        private readonly IScreenMessageTextChangeListener _textChangeListener;

        public ExplorerShowCommand(
            IExplorerViewsProvider viewsProvider,
            NavigationViewModel navigationViewModel,
            IScreenMessageTextChangeListener textChangeListener)
        {
            _viewsProvider = viewsProvider;
            _navigationViewModel = navigationViewModel;
            _textChangeListener = textChangeListener;
        }
        
        public void Show()
        {
            _viewsProvider.Bind();
            _textChangeListener.StartListen();
            _navigationViewModel.NavigateRoot();
        }
    }
}