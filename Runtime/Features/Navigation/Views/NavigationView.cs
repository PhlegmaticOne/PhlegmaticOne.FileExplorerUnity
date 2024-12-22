﻿using PhlegmaticOne.FileExplorer.ExplorerCore.ViewBase;
using PhlegmaticOne.FileExplorer.Features.Navigation.ViewModels;
using PhlegmaticOne.FileExplorer.Infrastructure.DependencyInjection.Attibutes;
using UnityEngine;
using UnityEngine.UI;

namespace PhlegmaticOne.FileExplorer.Features.Navigation.Views
{
    internal sealed class NavigationView : MonoBehaviour, IExplorerViewComponent
    {
        [SerializeField] private Button _backButton;
        [SerializeField] private LoadingTextView _loadingTextView;
        
        private NavigationViewModel _viewModel;

        [ViewInject]
        public void Construct(NavigationViewModel viewModel)
        {
            _viewModel = viewModel;
        }
        
        public void Bind()
        {
            _backButton.onClick.AddListener(NavigateBack);
            _viewModel.IsLoading.ValueChanged += UpdateLoadingState;
        }

        public void Unbind()
        {
            _backButton.onClick.RemoveListener(NavigateBack);
            _viewModel.IsLoading.ValueChanged -= UpdateLoadingState;
        }

        private void UpdateLoadingState(bool isLoading)
        {
            _loadingTextView.SetActive(isLoading);
            _backButton.interactable = _viewModel.CanMoveBack();
        }

        private void NavigateBack()
        {
            _viewModel.NavigateBack();
        }
    }
}