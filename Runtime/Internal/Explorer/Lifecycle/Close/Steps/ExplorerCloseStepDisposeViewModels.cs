using PhlegmaticOne.FileExplorer.Infrastructure.ViewModels;

namespace PhlegmaticOne.FileExplorer.Lifecycle.Close.Steps
{
    internal sealed class ExplorerCloseStepDisposeViewModels : IExplorerCloseStep
    {
        private readonly IViewModelDisposable[] _viewModelDisposables;

        public ExplorerCloseStepDisposeViewModels(
            IViewModelDisposable[] viewModelDisposables)
        {
            _viewModelDisposables = viewModelDisposables;
        }
        
        public void ProcessClose()
        {
            foreach (var viewModelDisposable in _viewModelDisposables)
            {
                viewModelDisposable.Dispose();
            }
        }
    }
}