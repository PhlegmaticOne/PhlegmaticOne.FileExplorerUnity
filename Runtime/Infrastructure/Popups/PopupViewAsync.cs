using System.Threading.Tasks;
using PhlegmaticOne.FileExplorer.Infrastructure.ViewModels;

namespace PhlegmaticOne.FileExplorer.Infrastructure.Popups
{
    internal abstract class PopupViewAsync<T> : PopupView where T : PopupViewModel
    {
        private TaskCompletionSource<bool> _viewResult;

        protected T PopupViewModel;
        
        public Task Show(T viewModel)
        {
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

        protected override ViewModel GetViewModel()
        {
            return PopupViewModel;
        }

        protected void Close()
        {
            _viewResult.TrySetResult(true);
            PopupViewModel.Release();
            PopupViewModel = null;
            _viewResult = null;
        }
    }
}