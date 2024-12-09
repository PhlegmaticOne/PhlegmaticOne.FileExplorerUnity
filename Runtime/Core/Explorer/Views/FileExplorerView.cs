using PhlegmaticOne.FileExplorer.Core.Explorer.ViewModels;
using PhlegmaticOne.FileExplorer.Core.Navigation.Views;
using UnityEngine;
using UnityEngine.UI;

namespace PhlegmaticOne.FileExplorer.Core.Explorer.Views
{
    internal sealed class FileExplorerView : MonoBehaviour
    {
        [SerializeField] private Canvas _canvas;
        [SerializeField] private NavigationView _navigationView;
        [SerializeField] private Button _closeButton;
        
        private FileExplorerViewModel _viewModel;

        public void Bind(FileExplorerViewModel viewModel)
        {
            _viewModel = viewModel;
            SetupCamera();
            Subscribe();
            BindNavigation();
        }

        private void Update()
        {
            if (!Input.GetKeyUp(KeyCode.Escape))
            {
                return;
            }

            if (_viewModel.NavigationViewModel.NavigateBack())
            {
                return;
            }
            
            CloseExplorer();
        }

        private void Subscribe()
        {
            _closeButton.onClick.AddListener(CloseExplorer);
        }

        private void SetupCamera()
        {
            _canvas.worldCamera = Camera.main;
        }

        private void BindNavigation()
        {
            var viewModel = _viewModel.NavigationViewModel;
            _navigationView.Bind(viewModel);
            viewModel.NavigateRoot();
        }

        private void CloseExplorer()
        {
            _viewModel.OnClosing();
            Destroy(gameObject);
            _viewModel = null;
        }
    }
}