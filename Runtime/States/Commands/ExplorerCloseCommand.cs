using PhlegmaticOne.FileExplorer.Core.ScreenMessages.Services;
using PhlegmaticOne.FileExplorer.Features.Cancellation;
using PhlegmaticOne.FileExplorer.Features.ExplorerIcons.Services;
using PhlegmaticOne.FileExplorer.Features.Views;
using UnityEngine;

namespace PhlegmaticOne.FileExplorer.States.Commands
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