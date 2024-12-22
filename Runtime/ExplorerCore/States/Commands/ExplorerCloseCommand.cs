using PhlegmaticOne.FileExplorer.ExplorerCore.Services.Cancellation;
using PhlegmaticOne.FileExplorer.ExplorerCore.Services.Disposing;
using PhlegmaticOne.FileExplorer.ExplorerCore.Services.RootObject;
using PhlegmaticOne.FileExplorer.ExplorerCore.Services.Views;
using PhlegmaticOne.FileExplorer.Features.FileEntries.Services.Icons.Services;
using PhlegmaticOne.FileExplorer.Features.ScreenMessages.Services;
using UnityEngine;

namespace PhlegmaticOne.FileExplorer.ExplorerCore.States.Commands
{
    internal sealed class ExplorerCloseCommand : IExplorerCloseCommand
    {
        private readonly IExplorerRootObjectProvider _rootObjectProvider;
        private readonly IExplorerViewsProvider _viewsProvider;
        private readonly IExplorerCancellationProvider _cancellationProvider;
        private readonly IExplorerViewModelDisposer _explorerViewModelDisposer;
        private readonly IScreenMessageTextChangeListener _textChangeListener;
        private readonly IExplorerIconsProvider _iconsProvider;

        public ExplorerCloseCommand(IExplorerRootObjectProvider rootObjectProvider,
            IExplorerViewsProvider viewsProvider,
            IExplorerCancellationProvider cancellationProvider,
            IExplorerViewModelDisposer explorerViewModelDisposer,
            IScreenMessageTextChangeListener textChangeListener,
            IExplorerIconsProvider iconsProvider)
        {
            _rootObjectProvider = rootObjectProvider;
            _viewsProvider = viewsProvider;
            _cancellationProvider = cancellationProvider;
            _explorerViewModelDisposer = explorerViewModelDisposer;
            _textChangeListener = textChangeListener;
            _iconsProvider = iconsProvider;
        }
        
        public void Close()
        {
            _cancellationProvider.Cancel();
            _textChangeListener.StopListen();
            _iconsProvider.Dispose();
            _viewsProvider.Unbind();
            _explorerViewModelDisposer.DisposeViewModels();
            Object.Destroy(_rootObjectProvider.RootObject);
        }
    }
}