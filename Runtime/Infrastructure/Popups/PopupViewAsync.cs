using System.Threading.Tasks;

namespace PhlegmaticOne.FileExplorer.Infrastructure.Popups
{
    internal abstract class PopupViewAsync<T> : PopupView where T : PopupViewModel
    {
        private TaskCompletionSource<bool> _viewResult;

        protected T PopupViewModel;
        
        public Task Show(T viewModel)
        {
            ViewModel = viewModel;
            PopupViewModel = viewModel;
            _viewResult = new TaskCompletionSource<bool>();
            OnShowing(viewModel);
            return _viewResult.Task;
        }

        protected abstract void OnShowing(T viewModel);

        public sealed override void Discard()
        {
            PopupViewModel.Discard();
            Close();
        }

        protected void Close()
        {
            _viewResult.TrySetResult(true);
            PopupViewModel.Release();
            ViewModel = null;
            _viewResult = null;
        }
    }
}