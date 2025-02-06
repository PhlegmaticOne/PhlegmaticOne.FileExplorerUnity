using PhlegmaticOne.FileExplorer.Features.FileEntries.Services.Icons.Services;
using PhlegmaticOne.FileExplorer.Services.Cancellation;
using PhlegmaticOne.FileExplorer.Services.Destroying;
using PhlegmaticOne.FileExplorer.Services.Disposing;
using PhlegmaticOne.FileExplorer.Services.Listeners;
using PhlegmaticOne.FileExplorer.Services.Views;

namespace PhlegmaticOne.FileExplorer.States.Commands
{
    internal sealed class ExplorerCloseCommand : IExplorerCloseCommand
    {
        private readonly IExplorerDestroyer _destroyer;
        private readonly IExplorerViewsProvider _viewsProvider;
        private readonly IExplorerCancellationProvider _cancellationProvider;
        private readonly IExplorerViewModelDisposer _explorerViewModelDisposer;
        private readonly ExplorerActionListeners _listeners;
        private readonly IExplorerIconsProvider _iconsProvider;

        public ExplorerCloseCommand(IExplorerDestroyer destroyer,
            IExplorerViewsProvider viewsProvider,
            IExplorerCancellationProvider cancellationProvider,
            IExplorerViewModelDisposer explorerViewModelDisposer,
            ExplorerActionListeners listeners,
            IExplorerIconsProvider iconsProvider)
        {
            _destroyer = destroyer;
            _viewsProvider = viewsProvider;
            _cancellationProvider = cancellationProvider;
            _explorerViewModelDisposer = explorerViewModelDisposer;
            _listeners = listeners;
            _iconsProvider = iconsProvider;
        }
        
        public void Close()
        {
            _cancellationProvider.Cancel();
            _listeners.StopListen();
            _iconsProvider.Dispose();
            _viewsProvider.Unbind();
            _explorerViewModelDisposer.DisposeViewModels();
            _destroyer.Destroy();
        }
    }
}