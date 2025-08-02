using System.Threading.Tasks;
using PhlegmaticOne.FileExplorer.Infrastructure.DependencyInjection.Attibutes;
using PhlegmaticOne.FileExplorer.Infrastructure.ViewModels.Commands;
using PhlegmaticOne.FileExplorer.Infrastructure.Views;
using PhlegmaticOne.FileExplorer.Infrastructure.Views.Components.Buttons;
using UnityEngine;

namespace PhlegmaticOne.FileExplorer.Infrastructure.Popups
{
    internal abstract class PopupView : View
    {
        [SerializeField] private ComponentButton _closeButton;
        
        private PopupViewModel _viewModel;

        protected void SetViewModelBase(PopupViewModel viewModel)
        {
            _viewModel = viewModel;
        }

        protected override void OnInitializing()
        {
            _closeButton.Bind(_viewModel.DiscardCommand);
        }

        public void Discard()
        {
            _viewModel.DiscardCommand.ExecuteWithoutParameter();
        }

        public virtual void Close() { }

        public override void Release()
        {
            _closeButton.Release();
            _viewModel = null;
        }
    }
    
    internal abstract class PopupView<T> : PopupView where T : PopupViewModel
    {
        private TaskCompletionSource<bool> _viewResult;

        protected T ViewModel;
        protected IViewProvider ViewProvider;

        [ViewInject]
        public void Construct(T viewModel, IViewProvider viewProvider)
        {
            _viewResult = new TaskCompletionSource<bool>();
            ViewProvider = viewProvider;
            ViewModel = viewModel;
            SetViewModelBase(viewModel);
        }
        
        public Task WaitClose()
        {
            return _viewResult.Task;
        }

        public override void Close()
        {
            _viewResult.TrySetResult(true);
            ViewModel = null;
            _viewResult = null;
        }
    }
}