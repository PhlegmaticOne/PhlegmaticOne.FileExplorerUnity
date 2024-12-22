using System;
using PhlegmaticOne.FileExplorer.Core.Actions.Views;
using PhlegmaticOne.FileExplorer.Core.Explorer.ViewModels;
using PhlegmaticOne.FileExplorer.Core.Navigation.Views;
using PhlegmaticOne.FileExplorer.Core.Path.Views;
using PhlegmaticOne.FileExplorer.Core.ScreenMessages.Views;
using PhlegmaticOne.FileExplorer.Core.Searching.Views;
using PhlegmaticOne.FileExplorer.Core.Selection.Views;
using PhlegmaticOne.FileExplorer.Core.Tab.Views;
using PhlegmaticOne.FileExplorer.Infrastructure.Popups;
using PhlegmaticOne.FileExplorer.Infrastructure.SafeArea;
using UnityEngine;
using UnityEngine.UI;

namespace PhlegmaticOne.FileExplorer.Core.Explorer.Views
{
    internal sealed class FileExplorerView : MonoBehaviour
    {
        [SerializeField] private Canvas _canvas;
        [SerializeField] private CanvasScaler _canvasScaler;
        [SerializeField] private TabView _tabView;
        [SerializeField] private NavigationView _navigationView;
        [SerializeField] private FileEntryActionsView _actionsView;
        [SerializeField] private SearchView _searchView;
        [SerializeField] private ScreenMessagesView _screenMessagesView;
        [SerializeField] private SelectionHeaderView _selectionHeaderView;
        [SerializeField] private PathView _pathView;
        [SerializeField] private Button _closeButton;
        [SerializeField] private PopupProvider _popupProvider;
        
        private FileExplorerViewModel _viewModel;

        public IPopupProvider PopupProvider => _popupProvider;

        public void Bind(FileExplorerViewModel viewModel)
        {
            _viewModel = viewModel;
            
            SetupCanvas();
            Subscribe();
            BindViews();
            
            _viewModel.NavigateRoot();
        }

        private void Awake()
        {
            SafeArea.Initialize(_canvasScaler.referenceResolution.x, _canvasScaler.referenceResolution.y);
        }

        private void Update()
        {
            if (!Input.GetKeyUp(KeyCode.Escape))
            {
                return;
            }

            if (_viewModel.SelectionViewModel.IsSelectionActive)
            {
                _viewModel.SelectionViewModel.ClearSelection();
                return;
            }
            
            if(!_viewModel.NavigationViewModel.NavigateBack())
            {
                CloseExplorer();
            }
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

        private void BindViews()
        {
            _actionsView.Bind(_viewModel.ActionsViewModel);
            _tabView.Bind(_viewModel.TabViewModel);
            _navigationView.Bind(_viewModel.NavigationViewModel);
            _selectionHeaderView.Bind(_viewModel.SelectionViewModel);
            _searchView.Bind(_viewModel.SearchViewModel);
            _screenMessagesView.Bind(_viewModel.ScreenMessagesViewModel);
            _pathView.Bind(_viewModel.PathViewModel);
        }

        private void CloseExplorer()
        {
            _viewModel.OnClosing();
            Destroy(gameObject);
            _viewModel = null;
        }
    }
}