using PhlegmaticOne.FileExplorer.Features.FileEntries.Services.Icons;
using PhlegmaticOne.FileExplorer.Services.ActionListeners;
using PhlegmaticOne.FileExplorer.Services.Cancellation;
using PhlegmaticOne.FileExplorer.Services.Destroying;
using PhlegmaticOne.FileExplorer.Services.StaticViews;
using PhlegmaticOne.FileExplorer.Services.ViewModelDisposing;

namespace PhlegmaticOne.FileExplorer.States.Commands
{
    internal sealed class ExplorerCloseCommand : IExplorerCloseCommand
    {
        private readonly IExplorerDestroyer _destroyer;
        private readonly IExplorerStaticViewComponentsProvider _staticViewComponentsProvider;
        private readonly IExplorerCancellationProvider _cancellationProvider;
        private readonly IExplorerViewModelDisposer _explorerViewModelDisposer;
        private readonly IExplorerActionListeners _listeners;
        private readonly IExplorerIconsProvider _iconsProvider;

        public ExplorerCloseCommand(IExplorerDestroyer destroyer,
            IExplorerStaticViewComponentsProvider staticViewComponentsProvider,
            IExplorerCancellationProvider cancellationProvider,
            IExplorerViewModelDisposer explorerViewModelDisposer,
            IExplorerActionListeners listeners,
            IExplorerIconsProvider iconsProvider)
        {
            _destroyer = destroyer;
            _staticViewComponentsProvider = staticViewComponentsProvider;
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
            _staticViewComponentsProvider.Unbind();
            _explorerViewModelDisposer.DisposeViewModels();
            _destroyer.Destroy();
        }
    }
}