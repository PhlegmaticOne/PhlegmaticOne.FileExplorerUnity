using System.Threading.Tasks;
using PhlegmaticOne.FileExplorer.Infrastructure.DependencyInjection.Attibutes;
using PhlegmaticOne.FileExplorer.Infrastructure.Views;

namespace PhlegmaticOne.FileExplorer.Infrastructure.Popups
{
    internal abstract class PopupViewAsync<T> : PopupView where T : PopupViewModel
    {
        private TaskCompletionSource<bool> _viewResult;

        protected T PopupViewModel;
        protected IViewProvider ViewProvider;

        [ViewInject]
        public void Construct(T viewModel, IViewProvider viewProvider)
        {
            _viewResult = new TaskCompletionSource<bool>();
            ViewProvider = viewProvider;
            PopupViewModel = viewModel;
            SetViewModelBase(viewModel);
        }
        
        public Task Show()
        {
            OnShowing(PopupViewModel);
            return _viewResult.Task;
        }

        public override void Close()
        {
            _viewResult.TrySetResult(true);
            PopupViewModel = null;
            _viewResult = null;
        }

        protected abstract void OnShowing(T viewModel);
    }
}