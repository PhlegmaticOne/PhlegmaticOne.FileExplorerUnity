using System.Threading.Tasks;
using UnityEngine;

namespace PhlegmaticOne.FileExplorer.Infrastructure.Views
{
    public abstract class View : MonoBehaviour
    {
        public abstract void Release();
        public abstract void Discard();
    }
    
    internal abstract class ViewAsync<T> : View where T : ViewModelBase
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