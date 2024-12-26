﻿using PhlegmaticOne.FileExplorer.ExplorerCore.Listeners;
using PhlegmaticOne.FileExplorer.ExplorerCore.Services.Cancellation;
using PhlegmaticOne.FileExplorer.ExplorerCore.Services.Destroying;
using PhlegmaticOne.FileExplorer.ExplorerCore.Services.Disposing;
using PhlegmaticOne.FileExplorer.ExplorerCore.Services.Views;
using PhlegmaticOne.FileExplorer.Features.FileEntries.Services.Icons.Services;

namespace PhlegmaticOne.FileExplorer.ExplorerCore.States.Commands
{
    internal sealed class ExplorerCloseCommand : IExplorerCloseCommand
    {
        private readonly IExplorerDestroyer _destroyer;
        private readonly IExplorerViewsProvider _viewsProvider;
        private readonly IExplorerCancellationProvider _cancellationProvider;
        private readonly IExplorerViewModelDisposer _explorerViewModelDisposer;
        private readonly IExplorerActionListener[] _listeners;
        private readonly IExplorerIconsProvider _iconsProvider;

        public ExplorerCloseCommand(IExplorerDestroyer destroyer,
            IExplorerViewsProvider viewsProvider,
            IExplorerCancellationProvider cancellationProvider,
            IExplorerViewModelDisposer explorerViewModelDisposer,
            IExplorerActionListener[] listeners,
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
            StopListen();
            _iconsProvider.Dispose();
            _viewsProvider.Unbind();
            _explorerViewModelDisposer.DisposeViewModels();
            _destroyer.Destroy();
        }

        private void StopListen()
        {
            foreach (var listener in _listeners)
            {
                listener.StopListen();
            }
        }
    }
}