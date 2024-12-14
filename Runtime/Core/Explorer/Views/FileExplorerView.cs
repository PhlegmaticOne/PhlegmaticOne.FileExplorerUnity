﻿using PhlegmaticOne.FileExplorer.Core.Actions.Views;
using PhlegmaticOne.FileExplorer.Core.Explorer.ViewModels;
using PhlegmaticOne.FileExplorer.Core.Navigation.Views;
using PhlegmaticOne.FileExplorer.Core.Tab.Views;
using PhlegmaticOne.FileExplorer.Infrastructure.Views;
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

        private void Update()
        {
            if (Input.GetKeyUp(KeyCode.Escape) && !_viewModel.NavigationViewModel.NavigateBack())
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
            _headerView.Bind(_viewModel.ActionsViewModel);
            _tabView.Bind(_viewModel.TabViewModel);
            _navigationView.Bind(_viewModel.NavigationViewModel);
        }

        private void CloseExplorer()
        {
            _viewModel.OnClosing();
            Destroy(gameObject);
            _viewModel = null;
        }
    }
}