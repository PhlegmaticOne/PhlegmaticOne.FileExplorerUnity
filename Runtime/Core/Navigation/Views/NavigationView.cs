using PhlegmaticOne.FileExplorer.Core.Navigation.ViewModels;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace PhlegmaticOne.FileExplorer.Core.Navigation.Views
{
    internal sealed class NavigationView : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _tabPathText;
        [SerializeField] private Button _backButton;
        [SerializeField] private LoadingTextView _loadingTextView;
        
        private NavigationViewModel _viewModel;

        public void Bind(NavigationViewModel viewModel)
        {
            _viewModel = viewModel;
            Subscribe();
        }

        private void UpdateLoadingState(bool isLoading)
        {
            _loadingTextView.SetActive(isLoading);
        }

        private void UpdatePath(string path)
        {
            _tabPathText.text = path;
            _backButton.interactable = _viewModel.CanMoveBack();
        }

        private void NavigateBack()
        {
            _viewModel.NavigateBack();
        }
        
        private void Subscribe()
        {
            _backButton.onClick.AddListener(NavigateBack);
            _viewModel.Path.ValueChanged += UpdatePath;
            _viewModel.IsLoading.ValueChanged += UpdateLoadingState;
        }
    }
}