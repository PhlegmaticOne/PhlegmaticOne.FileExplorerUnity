using PhlegmaticOne.FileExplorer.Core.Navigation.ViewModels;
using UnityEngine;
using UnityEngine.UI;

namespace PhlegmaticOne.FileExplorer.Core.Navigation.Views
{
    internal sealed class NavigationView : MonoBehaviour
    {
        [SerializeField] private Button _backButton;
        [SerializeField] private LoadingTextView _loadingTextView;
        
        private NavigationViewModel _viewModel;

        public void Bind(NavigationViewModel viewModel)
        {
            _viewModel = viewModel;
            _loadingTextView.Bind(viewModel);
            Subscribe();
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
        
        private void Subscribe()
        {
            _backButton.onClick.AddListener(NavigateBack);
            _viewModel.IsLoading.ValueChanged += UpdateLoadingState;
        }
    }
}