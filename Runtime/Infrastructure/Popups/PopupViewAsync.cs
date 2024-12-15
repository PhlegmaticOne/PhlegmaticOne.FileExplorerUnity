using System.Threading.Tasks;

namespace PhlegmaticOne.FileExplorer.Infrastructure.Popups
{
    internal abstract class PopupViewAsync<T> : PopupView where T : PopupViewModel
    {
        private TaskCompletionSource<bool> _viewResult;
        
        protected T ViewModel;

        public Task Show(T viewModel)
        {
            ViewModel = viewModel;
            _viewResult = new TaskCompletionSource<bool>();
            OnShowing(viewModel);
            return _viewResult.Task;
        }

        protected abstract void OnShowing(T viewModel);

        public sealed override void Discard()
        {
            ViewModel.Discard();
            Close();
        }

        protected void Close()
        {
            _viewResult.TrySetResult(true);
            ViewModel = null;
            _viewResult = null;
        }
    }
}