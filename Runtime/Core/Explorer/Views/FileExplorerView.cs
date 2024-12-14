using PhlegmaticOne.FileExplorer.Core.Actions.Views;
using PhlegmaticOne.FileExplorer.Core.Explorer.ViewModels;
using PhlegmaticOne.FileExplorer.Core.Navigation.Views;
using PhlegmaticOne.FileExplorer.Core.Tab.Views;
using UnityEngine;
using UnityEngine.UI;

namespace PhlegmaticOne.FileExplorer.Core.Explorer.Views
{
    internal sealed class FileExplorerView : MonoBehaviour
    {
        [SerializeField] private Canvas _canvas;
        [SerializeField] private TabView _tabView;
        [SerializeField] private NavigationView _navigationView;
        [SerializeField] private FileEntryActionsView _actionsView;
        [SerializeField] private FileExplorerHeaderView _headerView;
        [SerializeField] private Button _closeButton;
        
        private FileExplorerViewModel _viewModel;

        public void Bind(FileExplorerViewModel viewModel)
        {
            _viewModel = viewModel;
            SetupCanvas();
            Subscribe();
            BindActions();
            BindTab();
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

        private void SetupCanvas()
        {
            _canvas.worldCamera = Camera.main;
            _canvas.sortingOrder = 999;
        }

        private void BindActions()
        {
            _actionsView.Bind(_viewModel.ActionsViewModel);
            _headerView.Bind(_viewModel.ActionsViewModel);
        }

        private void BindTab()
        {
            _tabView.Bind(_viewModel.TabViewModel);
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